using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Infrastructure.Data;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using SchoolUser.Application.Mediator.RoleMediator.Queries;
using System.Globalization;

namespace SchoolUser.Domain.Services
{
    public class RegisterServices : IRegisterServices
    {
        private const string _entityName = "User";
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;
        private readonly IPasswordServices _passwordServices;
        private readonly ITokenServices _tokenServices;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _pepper;
        private readonly int _iteration;
        private readonly IMailServices _mailServices;
        private readonly IRoleServices _roleServices;
        private readonly IUserRoleServices _userRoleServices;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IGeneralUseConstants _generalUseConstants;
        private readonly IStudentServices _studentServices;
        private readonly ITeacherServices _teacherServices;
        private readonly IClassCategoryServices _classCategoryServices;
        private readonly IHelperServices _helperServices;
        private string _environmentName = "";

        public RegisterServices(ISender sender, IMapper mapper, IPasswordServices passwordServices, ITokenServices tokenServices,
        IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IMailServices mailServices, IRoleServices roleServices,
        IUserRoleServices userRoleServices, IReturnValueConstants returnValueConstants, IGeneralUseConstants generalUseConstants,
        DBContext dbContext, IStudentServices studentServices, ITeacherServices teacherServices, IClassCategoryServices classCategoryServices,
        IHelperServices helperServices)
        {
            _sender = sender;
            _mapper = mapper;
            _passwordServices = passwordServices;
            _tokenServices = tokenServices;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _pepper = _configuration.GetValue<string>("Password:Pepper")!;
            _iteration = _configuration.GetValue<int>("Password:Iteration");
            _mailServices = mailServices;
            _roleServices = roleServices;
            _userRoleServices = userRoleServices;
            _returnValueConstants = returnValueConstants;
            _generalUseConstants = generalUseConstants;
            _dbContext = dbContext;
            _studentServices = studentServices;
            _teacherServices = teacherServices;
            _classCategoryServices = classCategoryServices;
            _helperServices = helperServices;
            _environmentName = _webHostEnvironment.IsDevelopment() ? "Development" : "Production";
        }

        public async Task<UserResponseDto?> CreateUserService(UserAddRequestDto requestDto, string? tokenHeader)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var existingUser = await _sender.Send(new GetUserByEmailQuery(requestDto.EmailAddress));

                if (existingUser != null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"User with email {requestDto.EmailAddress}"));
                }

                string creatorName = "System";
                string creatorEmail = "system@email.com";
                bool isUserChildCreated = false;

                if (!tokenHeader.IsNullOrEmpty())
                {
                    string? cleanedToken = tokenHeader!.Replace("Bearer ", "");
                    var workingAdmin = await _sender.Send(new GetUserByJwtTokenQuery(cleanedToken));
                    creatorName = workingAdmin!.FullName;
                    creatorEmail = workingAdmin.EmailAddress;
                }

                #region check valid role

                Role? role = await _sender.Send(new GetRoleByTitleQuery(requestDto.RegisterForRole));

                List<Guid> submittedRoles =
                [
                    role!.Id
                ];

                List<Guid>? validRoles = await _roleServices.GetValidRoleIdsListService(submittedRoles);
                #endregion

                #region  check class category & class subject validity 
                bool isClassCategoryIdValid = false;

                if (requestDto.ClassCategoryId != null)
                {
                    isClassCategoryIdValid = await _classCategoryServices.GetByIdService((Guid)requestDto.ClassCategoryId) != null;

                    if (!isClassCategoryIdValid)
                    {
                        throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, $"Class Category"));
                    }
                }

                if (requestDto.RegisterForRole == "student" && requestDto.ClassSubjectIds == null && requestDto.ClassSubjectIds!.Count < 1)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
                }

                // check for admin registration 

                List<ClassSubject>? validClassSubject = [];
                List<Guid>? validClassSubjectIds = [];
                List<Guid>? selectedClassSubjectIds = [];

                if (requestDto.RegisterForRole == "student" && requestDto.RegisterForRole == "teacher")
                {
                    validClassSubject = (List<ClassSubject>?)await _sender.Send(new GetClassSubjectListByClassCategoryIdQuery((Guid)requestDto.ClassCategoryId!));
                    validClassSubjectIds = validClassSubject!.Select(cs => cs.Id).ToList();

                    if (requestDto.ClassSubjectIds != null && requestDto.ClassSubjectIds.Count > 0 && validClassSubjectIds != null && validClassSubjectIds.Count > 0)
                    {
                        selectedClassSubjectIds = requestDto.ClassSubjectIds.Intersect(validClassSubjectIds).ToList();
                    }
                }
                #endregion

                #region Create User

                User newUser = _mapper.Map<User>(requestDto);

                newUser.SerialTag = await _helperServices.CreateUserSerialTag(requestDto.RegisterForRole.ToLower());
                newUser.Id = Guid.NewGuid();
                newUser.BirthDate = requestDto.DateOfBirth.ToString(_generalUseConstants.DateFormat);
                newUser.Age = _helperServices.CalculateAge(requestDto.DateOfBirth);
                newUser.Gender = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestDto.Gender);

                var randomPassword = _passwordServices.CreateRandomPasswordService();
                newUser.IsChangedPassword = false;
                newUser.PasswordSalt = _passwordServices.GenerateSaltService();
                newUser.PasswordHash = _passwordServices.CreatePasswordHashService(randomPassword, newUser.PasswordSalt, _pepper, _iteration);

                newUser.IsConfirmedEmail = false;
                newUser.VerificationNumber = _tokenServices.CreateVerificationTokenService(6);
                newUser.VerificationExpiration = DateTime.Now.AddDays(7);

                newUser.IsActive = true;
                newUser.CreatedBy = creatorName;
                newUser.CreatedAt = DateTime.Now;
                newUser.UpdatedBy = creatorName;
                newUser.UpdatedAt = DateTime.Now;
                newUser.TokenExpiration = DateTime.Now;

                var createdUser = await _sender.Send(new AddUserCommand(newUser));

                if (createdUser == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, _entityName));
                }

                #endregion

                #region create student or teacher

                switch (requestDto.RegisterForRole.ToLower())
                {
                    case "student":
                        Student studentObj = new Student()
                        {
                            Id = Guid.NewGuid(),
                            EntranceYear = requestDto.EntranceYear != null ? requestDto.EntranceYear : DateTime.Now.Year,
                            EstimatedExitYear = requestDto.EstimatedExitYear != null ? requestDto.EstimatedExitYear : (DateTime.Now.Year + 6),
                            RealExitYear = null,
                            ExitReason = null,
                            UserId = newUser.Id,
                            ClassCategoryId = (Guid)requestDto.ClassCategoryId!,
                        };
                        (isUserChildCreated, createdUser.Student) = await _studentServices.CreateStudentService(createdUser, studentObj, selectedClassSubjectIds);
                        break;
                    case "teacher":
                        Teacher teacherObj = new Teacher()
                        {
                            Id = Guid.NewGuid(),
                            ServiceStatus = requestDto.ServiceStatus!,
                            IsAvailable = (bool)requestDto.IsAvailable!,
                            UserId = newUser.Id,
                            ClassCategoryId = requestDto.ClassCategoryId,
                        };
                        (isUserChildCreated, createdUser.Teacher) = await _teacherServices.CreateTeacherService(teacherObj, selectedClassSubjectIds);
                        break;
                    case "admin":
                        isUserChildCreated = true;
                        break;
                    default:
                        break;
                }

                if (isUserChildCreated && validRoles != null && validRoles.Any())
                {
                    await _userRoleServices.CreateUserRoleService(createdUser!.Id, validRoles!);
                    await transaction.CommitAsync();
                }

                var response = _mapper.Map<UserResponseDto>(createdUser);

                #endregion

                #region create and send mail

                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = createdUser.EmailAddress,
                    EmailToName = createdUser.FullName,
                    EmailCcId = creatorEmail,
                    EmailCcName = creatorName,
                    EmailSubject = $"[From {_environmentName}] Registration Successful",
                    EmailBody = $@"
                <html>
                    <head>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                line-height: 1.6;
                                margin: 20px;
                            }}
                            b {{
                                color: #000000;
                            }}
                            p {{
                                margin-bottom: 10px;
                            }}
                        </style>
                    </head>
                    <body>
                        <p><b>Greetings, {createdUser.FullName}</b></p>
                        <p>Here are the details of the registered account:</p>
                        <ul>
                            <li><b>Serial Tag:</b> {createdUser.SerialTag} </li>
                            <li><b>Fullname:</b> {createdUser.FullName}</li>
                            <li><b>Email Address:</b> {createdUser.MobileNumber}</li>
                            <li><b>Date Of Birth:</b> {createdUser.BirthDate}</li>
                            <li><b>Gender:</b> {createdUser.Gender}</li>
                            <li><b>Age:</b> {createdUser.Age}</li>
                            <li><b>Verification Number:</b> {newUser.VerificationNumber}</li>
                            <li><b>Password:</b> {randomPassword}</li>
                        </ul>
                        <p>Please verify the account within 7 days after the registration is completed.</p>
                    </body>
                </html>
                "
                };

                bool result = _mailServices.SendMailService(mailData, "registration email");

                if (!result)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.EMAIL_SENDING_ERROR, "registration email"));
                }

                #endregion

                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
            finally
            {
                transaction.Dispose();
            }

        }

        public async Task<bool> ExtendVerificationValidityService(string emailAddress, string? tokenHeader)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(emailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            string updatedByName = "System";
            string updatedByEmail = "system@email.com";

            if (!tokenHeader.IsNullOrEmpty())
            {
                string? cleanedToken = tokenHeader!.Replace("Bearer ", "");
                var workingAdmin = await _sender.Send(new GetUserByJwtTokenQuery(cleanedToken));
                updatedByName = workingAdmin!.FullName;
                updatedByEmail = workingAdmin.EmailAddress;
            }

            if (existingUser.VerificationExpiration > DateTime.Now)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.CODE_STILL_ACTIVE));
            }

            if (existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_HAS_BEEN_VERIFIED));
            }

            var randomPassword = _passwordServices.CreateRandomPasswordService();
            existingUser.IsChangedPassword = false;
            existingUser.PasswordSalt = _passwordServices.GenerateSaltService();
            existingUser.PasswordHash = _passwordServices.CreatePasswordHashService(randomPassword, existingUser.PasswordSalt, _pepper, _iteration);

            existingUser.IsConfirmedEmail = false;
            existingUser.VerificationNumber = _tokenServices.CreateVerificationTokenService(6);
            existingUser.VerificationExpiration = DateTime.Now.AddDays(3);
            existingUser.UpdatedBy = updatedByName;
            existingUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _sender.Send(new VerifyUserCommand(existingUser));

            #region create and send mail

            MailDataDto mailData = new MailDataDto()
            {
                EmailToId = updatedUser!.EmailAddress,
                EmailToName = updatedUser.FullName,
                EmailCcId = updatedByEmail,
                EmailCcName = updatedByName,
                EmailSubject = $"[From {_environmentName}] Account Verification Validity Extended",
                EmailBody = $@"
                <html>
                    <head>
                        <style>
                            body {{
                                font-family: 'Arial', sans-serif;
                                line-height: 1.6;
                                margin: 20px;
                            }}
                            b {{
                                color: #000000;
                            }}
                            p {{
                                margin-bottom: 10px;
                            }}
                        </style>
                    </head>
                    <body>
                        <p><b>Greetings, {updatedUser.FullName}</b></p>
                        <p>Your verification window is extended. Please verifiy your account again using the following details:</p>
                        <ul>
                            <li><b>Verification Number:</b> {updatedUser.VerificationNumber}</li>
                            <li><b>Password:</b> {randomPassword}</li>
                        </ul>
                        <p>Please verify the account within 3 days after receiving this email.</p>
                    </body>
                </html>
                "
            };

            bool result = _mailServices.SendMailService(mailData, "verification extension email");

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.EMAIL_SENDING_ERROR, "verification extension email"));
            }

            #endregion

            return result;
        }
    }
}
using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Infrastructure.Data;
using SchoolUser.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace SchoolUser.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly string _entityName = "User";
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IPasswordServices _passwordServices;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _pepper;
        private readonly int _iteration;
        private readonly IMailServices _mailServices;
        private readonly IHelperServices _helperServices;
        private readonly ITeacherServices _teacherServices;
        private readonly IStudentServices _studentServices;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly IGeneralUseConstants _generalUseConstants;
        private readonly DBContext _dbContext;
        private string _environmentName = "";

        public UserServices(ISender sender, IMapper mapper, IPasswordServices passwordServices, IConfiguration configuration,
        IWebHostEnvironment webHostEnvironment, IMailServices mailServices, IHelperServices helperServices,
        IReturnValueConstants returnValueConstants, DBContext dbContext, IGeneralUseConstants generalUseConstants,
        ITeacherServices teacherServices, IStudentServices studentServices)
        {
            _sender = sender;
            _mapper = mapper;
            _passwordServices = passwordServices;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _pepper = _configuration.GetValue<string>("Password:Pepper")!;
            _iteration = _configuration.GetValue<int>("Password:Iteration");
            _mailServices = mailServices;
            _helperServices = helperServices;
            _returnValueConstants = returnValueConstants;
            _generalUseConstants = generalUseConstants;
            _dbContext = dbContext;
            _teacherServices = teacherServices;
            _studentServices = studentServices;
            _environmentName = _webHostEnvironment.IsDevelopment() ? "Development" : "Production";
        }

        public async Task<UsersListResponseDto> GetAllUsersService(UsersListRequestDto? requestDto)
        {
            if (!requestDto!.IsActive && requestDto.PageNumber == 0 && requestDto.PageSize == 0 && requestDto.RoleTitle == null)
            {
                return await GetAllList();
            }

            return await GetPaginatedList(requestDto);
        }

        private async Task<UsersListResponseDto> GetAllList()
        {
            var listOfUsers = await _sender.Send(new GetAllUsersQuery());
            var listOfUsersDto = new List<UserResponseDto>();

            foreach (var user in listOfUsers!)
            {
                var dto = _mapper.Map<UserResponseDto>(user);
                listOfUsersDto.Add(dto);
            }

            return new UsersListResponseDto()
            {
                TotalUsers = listOfUsersDto.Count,
                ReturnedUsers = listOfUsersDto.Count,
                PaginationList = listOfUsersDto
            };
        }

        private async Task<UsersListResponseDto> GetPaginatedList(UsersListRequestDto requestDto)
        {
            var (listOfUsers, totalUsers) = await _sender.Send(new GetPaginatedUsersQuery(requestDto));
            var listOfUsersDto = new List<UserResponseDto>();

            foreach (var user in listOfUsers)
            {
                var dto = _mapper.Map<UserResponseDto>(user);
                listOfUsersDto.Add(dto);
            }

            return new UsersListResponseDto()
            {
                TotalUsers = totalUsers,
                ReturnedUsers = listOfUsersDto.Count,
                PaginationList = listOfUsersDto
            };
        }

        public async Task<UserResponseDto> GetUserByIdService(Guid id)
        {
            var user = await _sender.Send(new GetUserByIdQuery(id));
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> UpdateUserService(Guid id, UserUpdateRequestDto requestDto, string? tokenHeader)
        {
            if (requestDto == null)
            {
                throw new ArgumentNullException(nameof(requestDto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, _entityName));
            }

            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                bool isUserUpdated = false;
                bool isUserChildUpdated = false;

                User? existing = await _sender.Send(new GetUserByIdQuery(id));

                if (existing == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
                }

                string creatorName = "";

                if (!tokenHeader.IsNullOrEmpty())
                {
                    string? cleanedToken = tokenHeader!.Replace("Bearer ", "");
                    var workingAdmin = await _sender.Send(new GetUserByJwtTokenQuery(cleanedToken));
                    creatorName = workingAdmin!.FullName;
                }

                foreach (var ur in existing.Roles!)
                {
                    switch (ur.ToLower())
                    {
                        case "student":
                            existing.Student = await _studentServices.UpdateStudentService(requestDto!, existing.Student);
                            isUserChildUpdated = existing.Student != null;
                            break;
                        case "teacher":
                            existing.Teacher = await _teacherServices.UpdateTeacherService(requestDto!, existing.Teacher);
                            isUserChildUpdated = existing.Teacher != null;
                            break;
                        default:
                            //isUserChildUpdated = true;
                            break;
                    }
                }

                if (existing.FullName != requestDto.FullName ||
                existing.EmailAddress != requestDto.EmailAddress ||
                existing.MobileNumber != requestDto.MobileNumber ||
                existing.BirthDate != requestDto.DateOfBirth.ToString(_generalUseConstants.DateFormat) ||
                existing.Gender.ToLower() != requestDto.Gender.ToLower() ||
                existing.IsActive != requestDto.IsActive)
                {
                    var toUpdate = _mapper.Map<User>(requestDto);
                    toUpdate.BirthDate = requestDto.DateOfBirth.ToString(_generalUseConstants.DateFormat);
                    toUpdate.Age = _helperServices.CalculateAge(requestDto.DateOfBirth);
                    toUpdate.Gender = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(requestDto.Gender);
                    toUpdate.UpdatedBy = creatorName;
                    toUpdate.UpdatedAt = DateTime.Now;

                    existing = await _sender.Send(new UpdateUserCommand(toUpdate));
                    isUserUpdated = existing != null;
                }

                if (!isUserUpdated && !isUserChildUpdated)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, _entityName));
                }

                await transaction.CommitAsync();
                return _mapper.Map<UserResponseDto>(existing);
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

        public async Task<UserResponseDto> VerifyAccountService(UserVerifyAccountDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "UserVerifyAccountDto"));
            }

            var existingUser = await _sender.Send(new GetUserByEmailQuery(dto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (!existingUser.IsActive)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.USER_NOT_ACTIVE));
            }

            if (existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.CODE_INVALID, "Verification"));
            }

            if (DateTime.Now > existingUser.VerificationExpiration)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.CODE_EXPIRED, "Verification"));
            }

            if (dto.VerificationNumber != existingUser.VerificationNumber)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.WRONG_VERIFICATION_NO));
            }

            existingUser.EmailAddress = dto.EmailAddress;
            existingUser.MobileNumber = dto.MobileNumber;

            existingUser.IsConfirmedEmail = true;
            existingUser.VerificationNumber = "Completed";
            existingUser.VerificationExpiration = DateTime.Now;

            existingUser.UpdatedBy = existingUser.FullName;
            existingUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _sender.Send(new VerifyUserCommand(existingUser));
            return _mapper.Map<UserResponseDto>(updatedUser);
        }

        public async Task<UserResponseDto> ChangePasswordService(UserChangePasswordDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ChangePasswordDto"));
            }

            var existingUser = await _sender.Send(new GetUserByEmailQuery(dto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (!existingUser.IsActive)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.USER_NOT_ACTIVE));
            }

            if (!existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_NOT_VERIRIED));
            }

            var passwordHash = _passwordServices.CreatePasswordHashService(dto.OldPassword, existingUser.PasswordSalt, _pepper, _iteration);

            if (existingUser.PasswordHash != passwordHash)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.WRONG_OLD_PASSWORD));
            }

            existingUser.IsChangedPassword = true;
            existingUser.PasswordSalt = _passwordServices.GenerateSaltService();
            existingUser.PasswordHash = _passwordServices.CreatePasswordHashService(dto.NewPassword, existingUser.PasswordSalt, _pepper, _iteration);

            existingUser.UpdatedBy = existingUser.FullName;
            existingUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _sender.Send(new ChangePasswordCommand(existingUser));
            bool mailResult = false;

            if (updatedUser != null)
            {
                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = existingUser.EmailAddress,
                    EmailToName = existingUser.FullName,
                    EmailSubject = $"[From {_environmentName}] {string.Format(_returnValueConstants.SUCCESSFUL_CHANGE_PASSWORD)}",
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
                        <p><b>Greetings, {existingUser.FullName}</b></p>
                        <p>Your password for School Management System has been updated.</p>
                        <p>Please call the hotline if you do not perform this.</p>
                    </body>
                </html>
                "
                };

                mailResult = _mailServices.SendMailService(mailData, "change password email");
            }

            return _mapper.Map<UserResponseDto>(updatedUser);
        }

        public async Task<bool> ResetPasswordService(UserResetPasswordDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), string.Format(_returnValueConstants.ITEM_CANNOT_BE_NULL, "ResetPasswordDto"));
            }

            var existingUser = await _sender.Send(new GetUserByEmailQuery(dto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            if (!existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_NOT_VERIRIED));
            }

            var randomPassword = _passwordServices.CreateRandomPasswordService();
            existingUser.IsChangedPassword = false;
            existingUser.PasswordSalt = _passwordServices.GenerateSaltService();
            existingUser.PasswordHash = _passwordServices.CreatePasswordHashService(randomPassword, existingUser.PasswordSalt, _pepper, _iteration);

            existingUser.UpdatedBy = existingUser.FullName;
            existingUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _sender.Send(new ChangePasswordCommand(existingUser));
            bool mailResult = false;

            if (updatedUser != null)
            {
                MailDataDto mailData = new MailDataDto()
                {
                    EmailToId = existingUser.EmailAddress,
                    EmailToName = existingUser.FullName,
                    EmailSubject = $"[From {_environmentName}] {string.Format(_returnValueConstants.SUCCESSFUL_RESET_PASSWORD)}",
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
                        <p><b>Greetings, {existingUser.FullName}</b></p>
                        <p>Here is the your temporary password: {randomPassword}</p>
                        <p>Please change to your unique password for better security.</p>
                    </body>
                </html>
                "
                };

                mailResult = _mailServices.SendMailService(mailData, "reset password email");
            }

            return updatedUser != null && mailResult;
        }

        public async Task<bool> DeleteUserService(Guid id)
        {
            var existing = await _sender.Send(new GetUserByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, _entityName));
            }

            return await _sender.Send(new DeleteUserCommand(id));
        }
    }
}
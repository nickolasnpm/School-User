using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;
using Newtonsoft.Json;

namespace SchoolUser.Domain.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        private readonly IPasswordServices _passwordServices;
        private readonly ITokenServices _tokenServices;
        private readonly IConfiguration _configuration;
        private readonly string _pepper;
        private readonly int _iteration;
        private readonly IReturnValueConstants _returnValueConstants;

        public AuthServices(IMapper mapper, ISender sender, IPasswordServices passwordServices, ITokenServices tokenServices, IConfiguration configuration, IReturnValueConstants returnValueConstants)
        {
            _mapper = mapper;
            _sender = sender;
            _passwordServices = passwordServices;
            _tokenServices = tokenServices;
            _configuration = configuration;
            _pepper = _configuration.GetValue<string>("Password:Pepper")!;
            _iteration = _configuration.GetValue<int>("Password:Iteration");
            _returnValueConstants = returnValueConstants;
        }

        public async Task<LoginResponseDto?> LoginService(LoginRequestDto loginRequestDto)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(loginRequestDto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "The account"));
            }

            if (!existingUser.IsActive)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.USER_NOT_ACTIVE));
            }

            if (!existingUser.IsConfirmedEmail && existingUser.VerificationExpiration < DateTime.Now)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_NOT_VERIRIED));
            }

            var passwordHash = _passwordServices.CreatePasswordHashService(loginRequestDto.Password, existingUser.PasswordSalt, _pepper, _iteration);

            if (existingUser.PasswordHash != passwordHash)
            {
                throw new BusinessRuleException("Wrong Password.");
            }

            (existingUser.AccessToken, existingUser.TokenExpiration) = await _tokenServices.CreateJwtTokenService(existingUser);
            existingUser.RefreshToken = Guid.NewGuid().ToString();

            var userWithUpdatedToken = await _sender.Send(new UpdateTokenCommand(existingUser));

            if (userWithUpdatedToken == null)
            {
                throw new BusinessRuleException("Login failed");
            }

            return _mapper.Map<LoginResponseDto>(userWithUpdatedToken);
        }

        public async Task<bool> LogoutService(Guid id)
        {
            var existingUser = await _sender.Send(new GetUserByIdQuery(id));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "The account"));
            }

            existingUser.AccessToken = null;
            existingUser.RefreshToken = null;
            existingUser.TokenExpiration = DateTime.UtcNow.ToLocalTime();

            return await _sender.Send(new UpdateTokenCommand(existingUser)) != null;
        }
    }
}
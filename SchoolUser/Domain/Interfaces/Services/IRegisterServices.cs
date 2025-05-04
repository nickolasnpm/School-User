using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IRegisterServices
    {
        Task<UserResponseDto?> CreateUserService(UserAddRequestDto addUserRequestDto, string? tokenHeader);
        Task<bool> ExtendVerificationValidityService(string emailAddress, string? tokenHeader);
    }
}
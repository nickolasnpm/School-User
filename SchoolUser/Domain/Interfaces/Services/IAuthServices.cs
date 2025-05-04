using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IAuthServices
    {
        Task<LoginResponseDto?> LoginService(LoginRequestDto loginRequestDto);
        Task<bool> LogoutService(Guid id);
    }
}
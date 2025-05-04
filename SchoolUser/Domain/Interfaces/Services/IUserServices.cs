using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        Task<UsersListResponseDto> GetAllUsersService(UsersListRequestDto? requestDto);
        Task<UserResponseDto> GetUserByIdService(Guid id);
        Task<UserResponseDto> UpdateUserService(Guid id, UserUpdateRequestDto userUpdateDto, string userEmail);
        Task<UserResponseDto> VerifyAccountService(UserVerifyAccountDto verifyAccountDto);
        Task<UserResponseDto> ChangePasswordService(UserChangePasswordDto changePasswordDto);
        Task<bool> ResetPasswordService(UserResetPasswordDto resetPasswordDto);
        Task<bool> DeleteUserService(Guid id);
    }
}
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IQueryable<User>?> GetAllUsersAsync();
        Task<(IEnumerable<User>?, int)> GetPaginatedUsersAsync(UsersListRequestDto listRequestDto);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByJwtTokenAsync(string jwtToken);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> CreateAsync(User user);
        Task<User?> UpdateAsync(User user);
        Task<User?> VerifyUserAsync(User user);
        Task<User?> ChangePasswordAsync(User user);
        Task<User?> UpdateTokenAsync(User user);
        Task<bool> AutoUpdateUsersAgeAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteInactiveUsersAsync();
        Task<bool> DeleteUnregisteredUsersAsync();
        Task<User?> UpdateProfilePictureUriAsync(Guid id, string uri);
    }
}
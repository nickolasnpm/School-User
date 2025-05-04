using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories;

public interface IUserRoleRepository
{
    Task<UserRole?> CreateAsync(UserRole userRole);
    Task<bool> DeleteAsync(Guid id);
}

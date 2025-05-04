using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IRoleAccessModuleRepository
    {
        Task<IEnumerable<RoleAccessModule>?> GetByRoleIdAsync(Guid roleId);
        Task<IEnumerable<RoleAccessModule>?> GetByAccessModuleIdAsync(Guid accessModuleId);
        Task<RoleAccessModule?> CreateAsync(RoleAccessModule roleAccessModule);
        Task<bool> DeleteAsync(Guid roleId);
    }
}
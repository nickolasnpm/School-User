using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IRoleAccessModuleServices
    {
        Task<bool> CreateRoleAccessModuleService(AccessModule accessModule, List<Guid> roleIds);
        Task<bool> DeleteRoleAccessModuleService(AccessModule accessModule, List<Guid> accessModuleIds);
    }
}
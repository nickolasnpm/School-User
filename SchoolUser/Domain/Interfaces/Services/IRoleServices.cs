using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IRoleServices
    {
        Task<IEnumerable<Role>?> GetAllRolesService();
        Task<List<Guid>?> GetValidRoleIdsListService(List<Guid> roleIds);
        Task<Role?> GetRoleService(Guid id);
        Task<bool> CreateRoleService(RoleDto roleDto);
        Task<bool> UpdateRoleService(Guid id, RoleDto roleDto);
        Task<bool> DeleteRoleService(Guid id);
    }
}
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IUserRoleServices
    {
        Task<bool> CreateUserRoleService(Guid userId, List<Guid> roleIds);
    }
}
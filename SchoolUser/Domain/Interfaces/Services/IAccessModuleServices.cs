using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IAccessModuleServices
    {
        Task<IEnumerable<AccessModule>?> GetAllService();
        Task<AccessModule?> GetByIdService(Guid id);
        Task<bool> CreateService(AccessModuleDto accessModuleDto);
        Task<bool> UpdateService(Guid id, AccessModuleDto accessModuleDto);
        Task<bool> DeleteService(Guid id);
    }
}
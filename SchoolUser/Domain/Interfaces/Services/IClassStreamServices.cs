using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassStreamServices
    {
        Task<IEnumerable<ClassStream>?> GetAllService(bool? isActive);
        Task<ClassStream?> GetByIdService(Guid id);
        Task<bool> CreateService(ClassStreamDto ClassStreamDto);
        Task<bool> UpdateService(Guid id, ClassStreamDto ClassStreamDto);
        Task<bool> DeleteService(Guid id);
    }
}
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IBatchServices
    {
        Task<IEnumerable<Batch>?> GetAllService(bool? isActive);
        Task<Batch?> GetByIdService(Guid id);
        Task<Batch?> GetByNameService(string name);
        Task<bool> CreateService(BatchDto batchDto);
        Task<bool> UpdateService(Guid id, BatchDto batchDto);
        Task<bool> DeleteService(Guid id);
    }
}
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassRankServices
    {
        Task<IEnumerable<ClassRank>?> GetAllService(bool? isActive);
        Task<ClassRank?> GetByIdService(Guid id);
        Task<bool> CreateService(ClassRankDto classRankDto);
        Task<bool> UpdateService(Guid id, ClassRankDto classRankDto);
        Task<bool> DeleteService(Guid id);
    }
}
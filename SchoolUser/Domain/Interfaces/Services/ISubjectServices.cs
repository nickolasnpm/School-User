using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface ISubjectServices
    {
        Task<IEnumerable<Subject>?> GetAllService();
        Task<Subject?> GetByIdService(Guid id);
        Task<bool> CreateService(SubjectDto SubjectDto);
        Task<bool> UpdateService(Guid id, SubjectDto SubjectDto);
        Task<bool> DeleteService(Guid id);
    }
}
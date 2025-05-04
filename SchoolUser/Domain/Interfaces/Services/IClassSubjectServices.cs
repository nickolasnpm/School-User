using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassSubjectServices
    {
        Task<IEnumerable<ClassSubject>?> GetAllService();
        Task<ClassSubject?> GetByIdService(Guid id);
        Task<bool> CreateOfferedSubjectsService(ClassCategory classCategory, List<Guid> subjectIds);
        Task<bool> UpdateOfferedSubjectsService(ClassCategory classCategory, List<Guid> subjectIds);
        Task<bool> DeleteService(Guid id);
    }
}
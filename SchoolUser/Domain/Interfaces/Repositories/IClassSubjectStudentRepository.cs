using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassSubjectStudentRepository
    {
        Task<IEnumerable<ClassSubjectStudent>?> GetListByStudentIdAsync(Guid studentId);
        Task<IEnumerable<ClassSubjectStudent>?> GetListByClassSubjectIdAsync(Guid classSubjectId);
        Task<bool> CreateBulkAsync(List<ClassSubjectStudent> classSubjectStudents);
        Task<bool> DeleteBulkAsync(List<Guid> classSubjectIds);
    }
}
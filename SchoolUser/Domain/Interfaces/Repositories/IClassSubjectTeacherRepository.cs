using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassSubjectTeacherRepository
    {
        Task<IEnumerable<ClassSubjectTeacher>?> GetListByClasssSubjectIdAsync(Guid classSubjectId);
        Task<IEnumerable<ClassSubjectTeacher>?> GetListByTeacherIdAsync(Guid teacherId);
        Task<bool> CreateBulkAsync(List<ClassSubjectTeacher> classSubjectTeacher);
        Task<bool> DeleteBulkAsync(List<Guid> classSubjectIds);
    }
}
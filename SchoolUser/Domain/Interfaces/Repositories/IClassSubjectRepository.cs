using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassSubjectRepository
    {
        Task<IEnumerable<ClassSubject>?> GetAllAsync();
        Task<IEnumerable<ClassSubject>?> GetByClassCategoryIdAsync(Guid classCategoryId);
        Task<ClassSubject?> GetByIdAsync(Guid id);
        Task<ClassSubject?> GetByCodeAndYearAsync(string code, int year);
        Task<ClassSubject?> CreateAsync(ClassSubject classSubject);
        Task<ClassSubject?> UpdateAsync(ClassSubject classSubject);
        Task<bool> CreateBulkAsync(List<ClassSubject> classSubjects);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteBulkAsync(List<Guid> subjectIds);
    }
}
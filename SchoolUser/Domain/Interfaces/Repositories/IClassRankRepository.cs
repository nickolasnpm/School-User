using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassRankRepository
    {
        Task<IEnumerable<ClassRank>?> GetAllAsync(bool? isActive = null);
        Task<ClassRank?> GetByIdAsync(Guid id);
        Task<ClassRank?> GetByNameAsync(string Name);
        Task<ClassRank?> CreateAsync(ClassRank ClassRank);
        Task<ClassRank?> UpdateAsync(ClassRank ClassRank);
        Task<bool> DeleteAsync(Guid id);
    }
}
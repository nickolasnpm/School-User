using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IBatchRepository
    {
        Task<IEnumerable<Batch>?> GetAllAsync(bool? isActive = null);
        Task<Batch?> GetByIdAsync(Guid id);
        Task<Batch?> GetByNameAsync(string Name);
        Task<Batch?> CreateAsync(Batch batch);
        Task<Batch?> UpdateAsync(Batch batch);
        Task<bool> DeleteAsync(Guid id);
    }
}
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IAccessModuleRepository
    {
        Task<IEnumerable<AccessModule>?> GetAllAsync();
        Task<AccessModule?> GetByIdAsync(Guid id);
        Task<AccessModule?> GetByNameAsync(string name);
        Task<AccessModule?> CreateAsync(AccessModule accessModule);
        Task<AccessModule?> UpdateAsync(AccessModule accessModule);
        Task<bool> DeleteAsync(Guid id);
    }
}
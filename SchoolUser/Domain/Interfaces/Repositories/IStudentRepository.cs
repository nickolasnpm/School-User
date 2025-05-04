using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>?> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student?> GetByUserIdAsync(Guid userId);
        Task<Student?> CreateAsync(Student student);
        Task<Student?> UpdateAsync(Student student);
        Task<bool> UpdateBulkAsync(StudentsBulkUpdateDto updateStudentsDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
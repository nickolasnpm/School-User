using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassCategoryServices
    {
        Task<IEnumerable<ClassCategory>?> GetAllService();
        Task<ClassCategory?> GetByIdService(Guid id);
        Task<bool> CreateService(ClassCategoryDto ClassCategoryDto);
        Task<bool> UpdateOfferedSubjectService(Guid id, ClassCategoryDto ClassCategoryDto);
        Task<bool> DeleteService(Guid id);
    }
}
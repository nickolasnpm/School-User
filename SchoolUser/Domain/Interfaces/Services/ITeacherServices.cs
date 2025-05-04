using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface ITeacherServices
    {
        Task<(bool, Teacher)> CreateTeacherService(Teacher teacher, List<Guid>? classSubjectIds);
        Task<Teacher?> UpdateTeacherService(UserUpdateRequestDto requestDto, Teacher? teacher);
    }
}
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IStudentServices
    {
        Task<(bool, Student)> CreateStudentService(User user, Student student, List<Guid> classSubjectIds);
        Task<Student?> UpdateStudentService(UserUpdateRequestDto requestDto, Student? student);
        Task<bool> UpdateStudentInBulkService(StudentsBulkUpdateDto updateStudentsDto);
    }
}
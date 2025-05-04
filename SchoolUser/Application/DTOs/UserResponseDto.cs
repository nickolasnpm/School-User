using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public required string SerialTag { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string MobileNumber { get; set; }
        public required string DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public int Age { get; set; }
        public string? ProfilePictureUri { get; set; }
        public bool? IsActive { get; set; }
        public bool IsConfirmedEmail { get; set; }
        public bool IsChangedPassword { get; set; }
        public required List<string> Roles { get; set; }
        public StudentDto? Student { get; set; }
        public TeacherDto? Teacher { get; set; }
    }
}
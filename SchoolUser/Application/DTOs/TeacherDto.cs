using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }
        public string? ResponsibilityType { get; set; }
        public string? ResponsibilityFocus { get; set; }
        public Guid UserId { get; set; }
        public Guid? ClassCategoryId { get; set; }
        public List<ClassSubject>? ClassSubjects { get; set; }
    }
}
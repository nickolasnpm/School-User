using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public int? EntranceYear { get; set; }
        public int? EstimatedExitYear { get; set; }
        public int? RealExitYear { get; set; }
        public string? ExitReason { get; set; }
        public Guid UserId { get; set; }
        public Guid ClassCategoryId { get; set; }
        public List<ClassSubject>? ClassSubjects { get; set; }
    }
}
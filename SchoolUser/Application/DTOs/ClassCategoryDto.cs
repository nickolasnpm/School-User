using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    // class category can add or remove any subject that associated with it
    public class ClassCategoryDto
    {
        public int AcademicYear { get; set; }
        public Guid BatchId { get; set; }
        public Guid ClassStreamId { get; set; }
        public Guid ClassRankId { get; set; }
        public List<Guid>? SubjectIds { get; set; }
    }
}
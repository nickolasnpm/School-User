namespace SchoolUser.Application.DTOs
{
    // it can be created via add or update in Class Category, not by itself
    public class ClassSubjectDto
    {
        public Guid ClassCategoryId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
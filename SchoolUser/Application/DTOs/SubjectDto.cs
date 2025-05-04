namespace SchoolUser.Application.DTOs
{
    // subject cannot add or remove any class category associated with it
    public class SubjectDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public Guid TeacherId { get; set; }
    }
}
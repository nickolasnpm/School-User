namespace SchoolUser.Application.DTOs
{
    public class StudentToBePublishedDto
    {
        public required string StudentName { get; set; }
        public required string StudentId { get; set; }
        public string? ClassId { get; set; }
        public string? ClassName { get; set; }
        public required string EmailAddress { get; set; }
    }
}
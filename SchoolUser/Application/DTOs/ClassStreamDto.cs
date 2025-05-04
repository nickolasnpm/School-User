namespace SchoolUser.Application.DTOs
{
    public class ClassStreamDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public bool IsActive { get; set; }
    }
}
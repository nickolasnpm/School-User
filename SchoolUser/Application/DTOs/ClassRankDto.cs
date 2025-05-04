namespace SchoolUser.Application.DTOs
{
    public class ClassRankDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public bool IsActive { get; set; }
    }
}
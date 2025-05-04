namespace SchoolUser.Application.DTOs
{
    public class BatchDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public bool IsActive { get; set; }
        public Guid TeacherId { get; set; }
    }
}
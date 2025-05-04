namespace SchoolUser.Application.DTOs
{
    public class StudentsBulkUpdateDto
    {
        public required List<Guid> StudentIds { get; set; }
        public required int EntranceYear { get; set; }
        public required int EstimatedExitYear { get; set; }
        public required int RealExitYear { get; set; }
        public required string ExitReason { get; set; }
        public bool? IsActive { get; set; }
        public Guid? ClassCategoryId { get; set; }
    }
}
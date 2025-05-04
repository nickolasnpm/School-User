namespace SchoolUser.Application.DTOs
{
    public class UserUpdateRequestDto
    {
        public required string UpdateForRole { get; set; }
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public bool IsActive { get; set; }

        #region Teacher
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }
        public string? ResponsibilityType { get; set; }
        public string? ResponsibilityFocus { get; set; }
        #endregion

        #region Student
        public int? EntranceYear { get; set; }
        public int? EstimatedExitYear { get; set; }
        public int? RealExitYear { get; set; }
        public string? ExitReason { get; set; }
        #endregion

        public Guid? ClassCategoryId { get; set; }
        public List<Guid>? ClassSubjectIds { get; set; }
    }
}
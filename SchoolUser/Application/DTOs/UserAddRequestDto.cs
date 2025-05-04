namespace SchoolUser.Application.DTOs
{
    public class UserAddRequestDto
    {
        public required string RegisterForRole { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }

        #region Teacher
        public string? ServiceStatus { get; set; }
        public bool? IsAvailable { get; set; }
        #endregion

        #region Student
        public int? EntranceYear { get; set; }
        public int? EstimatedExitYear { get; set; }
        #endregion

        public Guid? ClassCategoryId { get; set; }
        public List<Guid>? ClassSubjectIds { get; set; }
    }
}
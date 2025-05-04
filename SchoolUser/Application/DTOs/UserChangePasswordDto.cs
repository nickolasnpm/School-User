namespace SchoolUser.Application.DTOs
{
    public class UserChangePasswordDto
    {
        public required string EmailAddress { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmNewPassword { get; set; }
    }
}
namespace SchoolUser.Application.DTOs
{
    public class UserVerifyAccountDto
    {
        public required string EmailAddress { get; set; }
        public required string MobileNumber { get; set; }
        public required string VerificationNumber { get; set; }
    }
}
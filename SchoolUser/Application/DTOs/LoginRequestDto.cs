namespace SchoolUser.Application.DTOs
{
    public class LoginRequestDto
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}
namespace SchoolUser.Application.DTOs
{
    public class UserRefreshJwtTokenDto
    {
        public required string EmailAddress { get; set; }
        public required string RefreshToken { get; set; }
    }
}
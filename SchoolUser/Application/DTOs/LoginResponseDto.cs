namespace SchoolUser.Application.DTOs
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}
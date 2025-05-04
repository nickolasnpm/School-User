namespace SchoolUser.Application.DTOs
{
    public class UserUpdateRolesDto
    {
        public Guid UserId { get; set; }
        public required List<string> Roles { get; set; }
    }
}
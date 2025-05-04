namespace SchoolUser.Application.DTOs
{
    public class UsersListRequestDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? RoleTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
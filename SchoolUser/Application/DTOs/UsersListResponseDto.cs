namespace SchoolUser.Application.DTOs
{
    public class UsersListResponseDto
    {
        public int TotalUsers { get; set; }
        public int ReturnedUsers { get; set; }
        public List<UserResponseDto>? PaginationList { get; set; }
    }
}
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.DTOs
{
    // accessmodule can add or delete role from associated with it
    public class AccessModuleDto
    {
        public required string Name { get; set; }
        public required List<Guid> RoleIds { get; set; }
    }
}
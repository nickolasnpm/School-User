using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class RoleAccessModule
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }
        public Guid RoleId { get; set; }

        [JsonIgnore]
        public AccessModule? AccessModule { get; set; }
        public Guid AccessModuleId { get; set; }
    }
}
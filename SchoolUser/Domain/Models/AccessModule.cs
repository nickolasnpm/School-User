using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class AccessModule
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore]
        public List<RoleAccessModule>? RoleAccessModules { get; set; }

        [NotMapped]
        public List<Role>? Roles { get; set; }

    }
}
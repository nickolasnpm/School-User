using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }

        #region Role - RoleAccessModule - AccessModule

        [JsonIgnore]
        public List<RoleAccessModule>? RoleAccessModules { get; set; }

        [NotMapped]
        public List<AccessModule>? AccessModules { get; set; }
        #endregion
    }
}
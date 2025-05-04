using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string SerialTag { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string MobileNumber { get; set; }
        public required string BirthDate { get; set; }
        public required string Gender { get; set; }
        public int Age { get; set; }
        public string? ProfilePictureUri { get; set; }
        public bool IsChangedPassword { get; set; }
        public required string PasswordSalt { get; set; }
        public required string PasswordHash { get; set; }
        public bool IsConfirmedEmail { get; set; }
        public required string VerificationNumber { get; set; }
        public DateTime VerificationExpiration { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public bool IsActive { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public required string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #region User - UserRole - Role
        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }

        [NotMapped]
        public List<string>? Roles { get; set; }
        #endregion

        [NotMapped]
        public Student? Student { get; set; }

        [NotMapped]
        public Teacher? Teacher { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string? ServiceStatus { get; set; }
        public bool IsAvailable { get; set; }
        public string? ResponsibilityType { get; set; }
        public string? ResponsibilityFocus { get; set; }

        #region Teacher - User
        [JsonIgnore]
        public User? User { get; set; }
        public Guid UserId { get; set; }
        #endregion

        #region Teacher - ClassCategory
        [JsonIgnore]
        public ClassCategory? ClassCategory { get; set; }
        public Guid? ClassCategoryId { get; set; }
        #endregion

        #region Teacher - ClassSubject
        [JsonIgnore]
        public List<ClassSubjectTeacher>? ClassSubjectTeachers { get; set; }

        [NotMapped]
        public List<ClassSubject>? ClassSubjects { get; set; }
        #endregion
    }
}
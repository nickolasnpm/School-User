using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public int? EntranceYear { get; set; }
        public int? EstimatedExitYear { get; set; }
        public int? RealExitYear { get; set; }
        public string? ExitReason { get; set; }

        #region Student - User
        [JsonIgnore]
        public User? User { get; set; }
        public Guid UserId { get; set; }
        #endregion

        #region Student - ClassCategory
        [JsonIgnore]
        public ClassCategory? ClassCategory { get; set; }
        public Guid? ClassCategoryId { get; set; }
        #endregion

        #region Student- ClassSubject
        [JsonIgnore]
        public List<ClassSubjectStudent>? ClassSubjectStudents { get; set; }

        [NotMapped]
        public List<ClassSubject>? ClassSubjects { get; set; }
        #endregion
    }
}
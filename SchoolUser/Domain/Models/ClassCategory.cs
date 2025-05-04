using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class ClassCategory
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public int AcademicYear { get; set; }

        #region Batch - ClassStream - ClassRank
        [JsonIgnore]
        public Batch? Batch { get; set; }
        public Guid BatchId { get; set; }

        [JsonIgnore]
        public ClassStream? ClassStream { get; set; }
        public Guid ClassStreamId { get; set; }

        [JsonIgnore]
        public ClassRank? ClassRank { get; set; }
        public Guid ClassRankId { get; set; }
        #endregion

        #region ClassCategory - ClassSubject - Subject
        public List<ClassSubject>? ClassSubjects { get; set; }

        [NotMapped]
        public List<string>? Subjects { get; set; }
        #endregion

        #region ClassCategory - Student/Teacher
        [NotMapped]
        public List<Student>? Students { get; set; }

        [NotMapped]
        public List<Teacher>? Teachers { get; set; }
        #endregion
    }
}
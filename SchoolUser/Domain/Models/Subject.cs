using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolUser.Domain.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public Guid? TeacherId { get; set; } // Link to which teacher that is supposed to manage this subject

        #region Subject - ClassSubject - ClassCategory
        public List<ClassSubject>? ClassSubjects { get; set; }

        [NotMapped]
        public List<string>? ClassCategories { get; set; }
        #endregion
    }
}
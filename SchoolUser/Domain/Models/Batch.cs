using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolUser.Domain.Models
{
    public class Batch
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public bool IsActive { get; set; }
        public Guid? TeacherId { get; set; } // Link to which teacher that is supposed to manage it

        #region Batch - ClassCategory
        public List<ClassCategory>? ClassCategories { get; set; }

        [NotMapped]
        public List<string>? ClassStreams { get; set; }

        [NotMapped]
        public List<string>? ClassRanks { get; set; }
        #endregion
    }
}
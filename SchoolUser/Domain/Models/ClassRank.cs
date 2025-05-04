using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolUser.Domain.Models
{
    public class ClassRank
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public bool IsActive { get; set; }

        #region ClassRank - ClassCategory
        public List<ClassCategory>? ClassCategories { get; set; }

        [NotMapped]
        public List<string>? Batches { get; set; }

        [NotMapped]
        public List<string>? ClassStreams { get; set; }
        #endregion
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolUser.Domain.Models
{
    public class ClassStream
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public bool IsActive { get; set; }

        #region ClassStream - ClassCategory
        public List<ClassCategory>? ClassCategories { get; set; }

        [NotMapped]
        public List<string>? Batches { get; set; }

        [NotMapped]
        public List<string>? ClassRanks { get; set; }

        #endregion
    }
}
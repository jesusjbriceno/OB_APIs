using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int CreatedByID { get; set; }
        [InverseProperty("BaseCreatedBy")]
        public virtual User CreatedBy { get; set; } = new User();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UpdatedByID { get; set; }
        [InverseProperty("BaseUpdatedBy")]
        public virtual User UpdatedBy { get; set; } = new User();
        public DateTime? UpdatedAt { get; set; }
        public int DeletedByID { get; set; }
        [InverseProperty("BaseDeletedBy")]
        public virtual User DeletedBy { get; set; } = new User();
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

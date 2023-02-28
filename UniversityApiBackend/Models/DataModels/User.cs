using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApiBackend.Models.DataModels
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Rol { get; set; } = "User";

        //[InverseProperty("CreatedBy")]
        //public virtual ICollection<BaseEntity> BaseCreatedBy {get;set;} = new List<BaseEntity>();
        //[InverseProperty("UpdatedBy")]
        //public virtual ICollection<BaseEntity> BaseUpdatedBy {get;set; } = new List<BaseEntity>();
        //[InverseProperty("DeletedBy")]
        //public virtual ICollection<BaseEntity> BaseDeletedBy {get;set; } = new List<BaseEntity>();
    }
}

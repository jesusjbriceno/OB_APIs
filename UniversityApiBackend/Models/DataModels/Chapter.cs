using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        public int CourseID { get; set; }
        public virtual Course Course { get; set; } = new Course();

        [Required]
        public string List { get; set; } = string.Empty;
    }
}

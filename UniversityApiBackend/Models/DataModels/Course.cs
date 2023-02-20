using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(200)]
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public string Objectives { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public EnumLevel Level { get; set; }
    }

    public enum EnumLevel
    {
        Basic=0,
        Medium=1,
        Advance=2
    }
}

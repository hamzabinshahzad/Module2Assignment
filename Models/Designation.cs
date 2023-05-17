using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        public string DesignationName { get; set; }
    }
}

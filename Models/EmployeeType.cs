using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeType
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        public string TypeName { get; set; }
    }
}

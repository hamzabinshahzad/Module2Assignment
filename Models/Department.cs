using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        public string DepartmentName { get; set; }
    }
}

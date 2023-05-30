using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$")]
        public string DepartmentName { get; set; }
    }
}

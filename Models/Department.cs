using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Department Name length must be between {1} and {2} characters!")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$", ErrorMessage = @"Department Name must only contain alphabets and spaces!")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; } // NAV
    }
}

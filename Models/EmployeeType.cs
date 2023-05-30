using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeType
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Employee Type Name length must be between {0} and {1} characters!")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$", ErrorMessage = @"Employee Type Name must only contain alphabets and spaces!")]
        public string TypeName { get; set; }
    }
}

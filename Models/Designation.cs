using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Designation Name length must be between {1} and {2} characters!")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$", ErrorMessage = @"Designation Name must only contain alphabets and spaces!")]
        public string DesignationName { get; set; }
    }
}

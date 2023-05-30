using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeType
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$")]
        public string TypeName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Street address must be between {0} and {1} of length!")]
        public string SteetAddress { get; set; }

        [Required]
        [RegularExpression(@"[^0-9]")]
        [StringLength(255, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"[^0-9]")]
        [StringLength(255, MinimumLength = 1)]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"[^0-9]")]
        [StringLength(255, MinimumLength = 1)]
        public string Country { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int EmployeeId { get; set; } // FK
    }
}

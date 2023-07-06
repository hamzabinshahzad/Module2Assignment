using ModuleAssignment.Filters.ValidationFilters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeAddress
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Street address must be between {1} and {2} of length!")]
        public string SteetAddress { get; set; }

        [Required]
        [ForbidNumericFilter]
        [StringLength(255, MinimumLength = 1, ErrorMessage = @"City name length must be between {1} and {2} characters long!")]
        public string City { get; set; }

        [Required]
        [ForbidNumericFilter]
        [StringLength(255, MinimumLength = 1, ErrorMessage = @"State name length must be between {1} and {2} characters long!")]
        public string State { get; set; }

        [Required]
        [ForbidNumericFilter]
        [StringLength(255, MinimumLength = 1, ErrorMessage = @"Country name length must be between {1} and {2} characters long!")]
        public string Country { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Employee ID must be between {1} and {2}")]
        public int EmployeeId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Employee? Employee { get; set; } // NAV
    }
}

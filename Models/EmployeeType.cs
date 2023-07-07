using ModuleAssignment.Filters.ValidationFilters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeType
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Employee Type Name length must be between {1} and {2} characters!")]
        [AlphaSpaceOnlyFilter]
        public string TypeName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Employee>? Employees { get; set; } // NAV
    }
}

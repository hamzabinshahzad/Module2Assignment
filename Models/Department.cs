using ModuleAssignment.Filters.ValidationFilters;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Department
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = @"Department Name length must be between {1} and {2} characters!")]
        [AlphaSpaceOnlyFilter]
        public string DepartmentName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Employee>? Employees { get; set; } // NAV
    }
}

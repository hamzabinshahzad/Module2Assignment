using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ModuleAssignment.Filters.ValidationFilters
{
    public class ForbidNumericFilter : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!Regex.Match(value.ToString(), @"^([^0-9]*)$").Success) return new ValidationResult("Cannot contain numeric digits!");
            else return ValidationResult.Success;
        }
    }
}

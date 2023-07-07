using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ModuleAssignment.Filters.ValidationFilters
{
    public class NumericOnlyFilter : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!Regex.Match(value.ToString(), @"^[0-9]+$").Success) return new ValidationResult("Must only contain numeric digits!");
            else return ValidationResult.Success;
        }
    }
}

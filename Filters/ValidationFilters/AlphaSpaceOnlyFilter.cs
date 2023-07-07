using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ModuleAssignment.Filters.ValidationFilters
{
    public class AlphaSpaceOnlyFilter : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!Regex.Match(value.ToString(), @"^[a-zA-Z]+[a-zA-Z ]*$").Success) return new ValidationResult("Must only contain alphabets and spaces!");
            else return ValidationResult.Success;
        }
    }
}

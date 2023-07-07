using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ModuleAssignment.Filters.ValidationFilters
{
    public class AlphabetOnlyFilter : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!Regex.Match(value.ToString(), @"^[a-zA-Z]+$").Success) return new ValidationResult("Must only contains alphabets!");
            else return ValidationResult.Success;
        }
    }
}

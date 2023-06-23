using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = @"Username length must be between {1} and {2} characters!")]
        [RegularExpression(@"^[0-9a-zA-Z_-.]+[a-zA-Z0-9_-. ]*$", ErrorMessage = "Username must only contain alphabets, spaces, numbers, underscore, dash and periods and should not begin with a space!")]
        public string Username { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 8, ErrorMessage = @"Password length must be between {1} and {2} characters!")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = @"Role length must be between {1} and {2} characters!")]
        [RegularExpression(@"^[a-z]+$", ErrorMessage = "Role must only contain lowercase alphabets!")]
        public string Role { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = @"Valid ID for Employee must be between {1} and {2}")]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; } // NAV
    }
}

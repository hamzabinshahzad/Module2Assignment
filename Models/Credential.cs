using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; } // NAV
    }
}

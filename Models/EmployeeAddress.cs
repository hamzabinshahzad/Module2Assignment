using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        public string SteetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int EmployeeId { get; set; } // FK
    }
}

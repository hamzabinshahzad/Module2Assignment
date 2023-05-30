using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(256, MinimumLength = 5, ErrorMessage = @"Full Name length must be between {0} and {1} letters!")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Gender { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15, ErrorMessage = @"CNIC length must be {0} characters and can only contain digits and dashes!")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$")]
        public string Cnic { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 10, ErrorMessage = @"Mobile Phone number length must be between {0} and {1} digits!")]
        [RegularExpression(@"^[0-9]+$")]
        public string Mobile { get; set; }

        [Required]
        [Range(0, 5000000)]
        public decimal Salary { get; set; }

        [Required]
        public int ReportsToEmpId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int EmpTypeId { get; set; } // FK

        [Required]
        [Range(1, int.MaxValue)]
        public int DeptId { get; set; } // FK

        [Required]
        [Range(1, int.MaxValue)]
        public int DesignationId { get; set; } // FK
    }
}

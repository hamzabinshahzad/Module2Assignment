using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(256, MinimumLength = 5, ErrorMessage = @"Full Name length must be between {0} and {1} alphabets!")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$", ErrorMessage = "Full Name must only contain alphabets and spaces!")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Gender field must only contains alphabets!")]
        public string Gender { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15, ErrorMessage = @"CNIC length must be {0} characters and can only contain digits and dashes!")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$", ErrorMessage = "Correct format for CNIC is: XXXXX-XXXXXXX-X")]
        public string Cnic { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format, please try again.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 10, ErrorMessage = @"Mobile Phone number length must be between {0} and {1} digits!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = @"Mobile Phone number must only contain numeric digits!")]
        public string Mobile { get; set; }

        [Required]
        [Range(0, 5000000, ErrorMessage = @"Valid salary must be between {0} and {1}")]
        public decimal Salary { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = @"Valid ID for Reporting Employee must be between {0} and {1}")]
        public int ReportsToEmpId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Valid Employee Type ID must be between {0} and {1}")]
        public int EmpTypeId { get; set; } // FK

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Valid Department ID must be between {0} and {1}")]
        public int DeptId { get; set; } // FK

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Valid Designation ID must be between {0} and {1}")]
        public int DesignationId { get; set; } // FK
    }
}

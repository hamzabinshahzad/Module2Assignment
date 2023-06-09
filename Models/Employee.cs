using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Employee
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        public int Id { get; set; } // PK

        [Required]
        [StringLength(256, MinimumLength = 5, ErrorMessage = @"Full Name length must be between {1} and {2} alphabets!")]
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z ]*$", ErrorMessage = "Full Name must only contain alphabets and spaces!")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Gender field must only contains alphabets!")]
        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15, ErrorMessage = @"CNIC length must be {1} characters and can only contain digits and dashes!")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$", ErrorMessage = "Correct format for CNIC is: XXXXX-XXXXXXX-X")]
        public string Cnic { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format, please try again.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 10, ErrorMessage = @"Mobile Phone number length must be between {1} and {2} digits!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = @"Mobile Phone number must only contain numeric digits!")]
        public string Mobile { get; set; }

        [Required]
        [Range(0, 5000000, ErrorMessage = @"Valid salary must be between {1} and {2}")]
        public decimal Salary { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = @"Valid ID for Reporting Employee must be between {1} and {2}")]
        public int ReportsToEmployeeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Valid Employee Type ID must be between {1} and {2}")]
        public int EmployeeTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Valid Department ID must be between {1} and {2}")]
        public int DepartmentId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = @"Valid Designation ID must be between {1} and {2}")]
        public int DesignationId { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Employee? ReportsToEmployee { get; set; } // NAV
        
        [SwaggerSchema(ReadOnly = true)]
        public virtual EmployeeType? EmployeeType { get; set; } // NAV
        
        [SwaggerSchema(ReadOnly = true)]
        public virtual Department? Department { get; set; } // NAV
        
        [SwaggerSchema(ReadOnly = true)]
        public virtual Designation? Designation { get; set; } // NAV
        
        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<EmployeeAddress>? EmployeeAddresses { get; set; } // NAV

        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Credential>? Credentials { get; set; } // NAV
    }
}

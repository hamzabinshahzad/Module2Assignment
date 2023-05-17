using System.ComponentModel.DataAnnotations;

namespace ModuleAssignment.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } // PK

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Cnic { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public int ReportsToEmpId { get; set; }

        [Required]
        public int EmpTypeId { get; set; } // FK

        [Required]
        public int DeptId { get; set; } // FK

        [Required]
        public int DesignationId { get; set; } // FK
    }
}

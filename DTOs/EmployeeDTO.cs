namespace ModuleAssignment.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Cnic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public decimal Salary { get; set; }
        public int ReportsToEmployeeId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
    }
}

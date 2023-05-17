using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Models;

namespace ModuleAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> employeeAddresses { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> DepartmentDesignations { get; set; }
    }
}

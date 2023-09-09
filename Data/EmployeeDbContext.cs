using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Models;

namespace ModuleAssignment.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}

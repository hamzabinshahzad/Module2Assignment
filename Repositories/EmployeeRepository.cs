using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore.Metadata;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    { 
        private readonly EmployeeDbContext Context;

        public EmployeeRepository(EmployeeDbContext IncomingContext) : base(IncomingContext)
        {
            Context = IncomingContext;
        }

        public IQueryable GetEmployeeDetailsById(int id)
        {
            var Emp = Context.Employees
                .Where(emp => emp.Id == id)
                .Join(Context.Departments, emp => emp.DeptId, dept => dept.Id, (emp, dept) => new { emp, dept.DepartmentName })
                .Join(Context.EmployeeTypes, data => data.emp.EmpTypeId, empType => empType.Id, (data, empType) => new { data.emp, data.DepartmentName, empType.TypeName })
                .Join(Context.Designations, data => data.emp.DesignationId, ds => ds.Id, (data, ds) => new { data.emp, data.DepartmentName, data.TypeName, ds.DesignationName })
                .Select(data => new
                {
                    data.emp.FullName,
                    data.emp.Gender,
                    data.emp.Cnic,
                    data.emp.DateOfBirth,
                    data.emp.Mobile,
                    data.DesignationName,
                    data.TypeName,
                    data.DepartmentName
                }
            );

            if (Emp != null) return Emp;
            else return null;
        }

    }
}

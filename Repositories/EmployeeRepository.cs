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
                    data.emp.EmailAddress,
                    data.emp.Gender,
                    data.emp.Cnic,
                    data.emp.DateOfBirth,
                    data.emp.Mobile,
                    data.DesignationName,
                    data.TypeName,
                    data.DepartmentName
                }
            );

            return Emp;
        }


        public IQueryable GetAddressById(int id)
        {
            var EmpAddress = Context.Employees
                .Where(emps => emps.Id == id)
                .Join(Context.EmployeeAddresses, emp => emp.Id, addr => addr.EmployeeId, (emp, addr) => new { emp.FullName, addr })
                .Select(data => new
                {
                    EmployeeName = data.FullName,
                    data.addr.SteetAddress,
                    data.addr.City,
                    data.addr.State,
                    data.addr.Country
                });

            return EmpAddress;
        }


        public IQueryable GetEmployeeDetailsByEmail(string emailAddress)
        {
            var Emp = Context.Employees
                .Where(emp => emp.EmailAddress == emailAddress)
                .Join(Context.Departments, emp => emp.DeptId, dept => dept.Id, (emp, dept) => new { emp, dept.DepartmentName })
                .Join(Context.EmployeeTypes, data => data.emp.EmpTypeId, empType => empType.Id, (data, empType) => new { data.emp, data.DepartmentName, empType.TypeName })
                .Join(Context.Designations, data => data.emp.DesignationId, ds => ds.Id, (data, ds) => new { data.emp, data.DepartmentName, data.TypeName, ds.DesignationName })
                .Select(data => new
                {
                    data.emp.FullName,
                    data.emp.EmailAddress,
                    data.emp.Gender,
                    data.emp.Cnic,
                    data.emp.DateOfBirth,
                    data.emp.Mobile,
                    data.DesignationName,
                    data.TypeName,
                    data.DepartmentName
                }
            );

            return Emp;
        }


    }
}

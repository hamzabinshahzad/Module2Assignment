using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly EmployeeDbContext Context;
        
        public DepartmentRepository(EmployeeDbContext IncomingContext) : base(IncomingContext)
        {
            Context = IncomingContext;
        }


        public int NumberOfEmployeesInDepartment(int id)
        {
            //var EmpCount = Context.Departments
            //    .Where(dept => dept.Id == id)
            //    .Join(Context.Employees, dept => dept.Id, emp => emp.DeptId,
            //            (dept, emp) => new { }
            //).Count();

            //return EmpCount;
            var EmpCount = Context.Departments
                .Where(dept => dept.Id == id)
                .Include("Employees")
                .Count();

            return EmpCount;
        }


        public IQueryable NumberOfEmployeesInAllDepartments()
        {
            //var EmpCountDeptList = Context.Departments
            //    .Join(Context.Employees, dept => dept.Id, emp => emp.DeptId, (dept, emp) => new { dept, emp })
            //    .GroupBy(data => data.dept.DepartmentName)
            //    .Select(data => new
            //    {
            //        DepartmentName = data.Key,
            //        TotalEmployees = data.Count()
            //    });

            //return EmpCountDeptList;
            var EmpCountDeptList = Context.Departments
                .Include("Employees")
                .GroupBy(dept => dept.DepartmentName)
                .Select(dept => new
                {
                    DepartmentName = dept.Key,
                    TotalEmployees = dept.Count()
                });

            return EmpCountDeptList;
        }


    }
}

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
            var EmpCount = Context.Departments
                .Where(dept => dept.Id == id)
                .Join(Context.Employees, dept => dept.Id, emp => emp.DeptId,
                        (dept, emp) => new { }
            ).Count();

            return EmpCount;
        }


        public dynamic NumberOfEmployeesInAllDepartments()
        {
            //var EmpCounDeptList = Context.Departments.ToList();
            //foreach(var dept in EmpCounDeptList)
            //{
            //    NumberOfEmployeesInDepartment(dept.Id);
            //}
            var EmpCountDeptList = Context.Departments
                .Join(Context.Employees, dept => dept.Id, emp => emp.DeptId, (dept, emp) => new { dept, emp })
                .Select(data => new
                {
                    data.dept.DepartmentName,
                    data.emp.FullName
                })
                .GroupBy(data => data.DepartmentName)
                .Count();


            return EmpCountDeptList;
        }


    }
}

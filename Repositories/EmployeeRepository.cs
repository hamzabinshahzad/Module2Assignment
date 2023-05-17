using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbSet<Employee> DbSet;

        public EmployeeRepository(AppDbContext IncomingContext)
        {
            this.DbSet = IncomingContext.Set<Employee>();
        }


        public void Add(Employee employee)
        {
            DbSet.Add(employee);
        }


        public void Delete(int id)
        {
            var Employee = DbSet.Find(id);
            if(Employee != null) DbSet.Remove(Employee);
        }


        public IEnumerable<Employee> GetAll()
        {
            var Employees = DbSet.ToList();
            if (Employees != null) return Employees;
            else return null;
        }


        public Employee GetById(int id)
        {
            var Employee = DbSet.Find(id);
            if (Employee != null) return Employee;
            else return null;
        }


        public void Update(Employee employee)
        {
            if (employee.Id > 0) DbSet.Update(employee);
        }


    }
}

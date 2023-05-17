using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbSet<Department> DbSet;

        public DepartmentRepository(AppDbContext IncomingContext)
        {
            this.DbSet = IncomingContext.Set<Department>();
        }


        public void Add(Department department)
        {
            DbSet.Add(department);
        }


        public void Delete(int id)
        {
            var Department = DbSet.Find(id);
            if(Department != null) DbSet.Remove(Department);
        }


        public IEnumerable<Department> GetAll()
        {
            var Departments = DbSet.ToList();
            return Departments;
        }


        public Department GetById(int id)
        {
            var Department = DbSet.Find(id);

            if (Department != null) return Department;
            else return null;
        }


        public void Update(Department department)
        {
            var DepartmentUpdate = DbSet.Find(department.Id);
            if(DepartmentUpdate != null) DepartmentUpdate.DepartmentName = department.DepartmentName;
        }


    }
}

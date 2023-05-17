using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly DbSet<EmployeeType> DbSet;

        public EmployeeTypeRepository(AppDbContext IncomingContext)
        {
            this.DbSet = IncomingContext.Set<EmployeeType>();
        }


        public void Add(EmployeeType type)
        {
            DbSet.Add(type);
        }


        public void Delete(int id)
        {
            var EmpType = DbSet.Find(id);
            if(EmpType != null) DbSet.Remove(EmpType);
        }


        public IEnumerable<EmployeeType> GetAll()
        {
            var EmpTypes = DbSet.ToList();
            if (EmpTypes != null) return EmpTypes;
            else return null;
        }


        public EmployeeType GetById(int id)
        {
            var EmpType = DbSet.Find(id);
            if (EmpType != null) return EmpType;
            else return null;
        }


        public void Update(EmployeeType type)
        {
            if(type.Id > 0) DbSet.Update(type);
        }


    }
}

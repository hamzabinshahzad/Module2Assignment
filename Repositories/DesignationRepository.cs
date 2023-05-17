using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly DbSet<Designation> DbSet;

        public DesignationRepository(AppDbContext IncomingContext)
        {
            this.DbSet = IncomingContext.Set<Designation>();
        }


        public void Add(Designation designation)
        {
            DbSet.Add(designation);
        }


        public void Delete(int id)
        {
            var Designation = DbSet.Find(id);
            if(Designation != null) DbSet.Remove(Designation);
        }


        public IEnumerable<Designation> GetAll()
        {
            var Designations = DbSet.ToList();
            if (Designations != null) return Designations;
            else return null;
        }


        public Designation GetById(int id)
        {
            var Designation = DbSet.Find(id);
            if (Designation != null) return Designation;
            else return null;
        }


        public void Update(Designation designation)
        {
            if (designation.Id > 0) DbSet.Update(designation);
        }


    }
}

using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeDbContext Context;
        private readonly DbSet<T> DbSet;

        public GenericRepository(EmployeeDbContext IncomingContext)
        {
            this.Context = IncomingContext;
            this.DbSet = Context.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }


        public void Delete(int id)
        {
            var Entity = DbSet.Find(id);
            if (Entity != null) DbSet.Remove(Entity);
        }


        public IEnumerable<T> GetAll()
        {
            var Entity = DbSet.ToList();
            if (Entity != null) return Entity;
            else return null;
        }


        public T GetById(int id)
        {
            var Entity = DbSet.Find(id);
            if (Entity != null) return Entity;
            else return null;
        }


        public void Update(T Entity)
        {
            DbSet.Update(Entity);
        }


    }
}

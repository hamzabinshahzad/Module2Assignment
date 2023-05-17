using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> DbSet;

        public GenericRepository(AppDbContext IncomingContext)
        {
            this.DbSet = IncomingContext.Set<T>();
        }

        public void Add(T obj)
        {
            DbSet.Add(obj);
        }


        public void Delete(int id)
        {
            var Obj = DbSet.Find(id);
            if (Obj != null) DbSet.Remove(Obj);
        }


        public IEnumerable<T> GetAll()
        {
            var Obj = DbSet.ToList();
            if (Obj != null) return Obj;
            else return null;
        }


        public T GetById(int id)
        {
            var Obj = DbSet.Find(id);
            if (Obj != null) return Obj;
            else return null;
        }


        public void Update(T obj)
        {
            DbSet.Update(obj);
        }


    }
}

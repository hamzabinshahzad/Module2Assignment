
namespace ModuleAssignment.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T designation);
        void Update(T designation);
        void Delete(int id);
    }
}

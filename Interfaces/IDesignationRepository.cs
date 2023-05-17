using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IDesignationRepository
    {
        IEnumerable<Designation> GetAll();
        Designation GetById(int id);
        void Add(Designation designation);
        void Update(Designation designation);
        void Delete(int id);
    }
}

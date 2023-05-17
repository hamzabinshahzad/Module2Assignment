using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IEmployeeTypeRepository
    {
        IEnumerable<EmployeeType> GetAll();
        EmployeeType GetById(int id);
        void Add(EmployeeType type);
        void Update(EmployeeType type);
        void Delete(int id);
    }
}

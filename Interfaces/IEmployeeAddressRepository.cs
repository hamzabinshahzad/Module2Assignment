using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IEmployeeAddressRepository
    {
        IEnumerable<EmployeeAddress> GetAll();
        EmployeeAddress GetById(int id);
        void Add(EmployeeAddress address);
        void Update(EmployeeAddress address);
        void Delete(int id);
    }
}

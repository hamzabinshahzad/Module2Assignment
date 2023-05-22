using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Services
{
    public interface IUnitofWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IGenericRepository<EmployeeAddress> EmployeeAddressRepository { get; }
        IGenericRepository<EmployeeType> EmployeeTypeRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        IGenericRepository<Designation> DesignationRepository { get; }

        void Commit();
    }
}

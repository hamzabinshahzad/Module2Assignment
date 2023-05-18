using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IUnitofWork
    {
        IGenericRepository<Employee> EmployeeRepository { get; }
        IGenericRepository<EmployeeAddress> EmployeeAddressRepository { get; }
        IGenericRepository<EmployeeType> EmployeeTypeRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        IGenericRepository<Designation> DesignationRepository { get; }

        void Commit();
        void Dispose();
    }
}

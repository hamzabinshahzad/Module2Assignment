using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IUnitofWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeAddressRepository EmployeeAddressRepository { get; }
        IEmployeeTypeRepository EmployeeTypeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IDesignationRepository DesignationRepository { get; }

        void Commit();
    }
}

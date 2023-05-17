using ModuleAssignment.Interfaces;

namespace ModuleAssignment.Services
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeAddressRepository EmployeeAddressRepository { get; }
        IEmployeeTypeRepository EmployeeTypeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IDesignationRepository DesignationRepository { get; }

        void Commit();
        void Rollback();
    }
}

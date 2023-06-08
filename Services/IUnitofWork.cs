using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Services
{
    public interface IUnitofWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IGenericRepository<EmployeeAddress> EmployeeAddressRepository { get; }
        IGenericRepository<EmployeeType> EmployeeTypeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IGenericRepository<Designation> DesignationRepository { get; }
        IGenericRepository<Credential> CredentialRepository { get; }

        int Commit();
    }
}

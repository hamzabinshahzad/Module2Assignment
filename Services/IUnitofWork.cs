using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Services
{
    public interface IUnitofWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IEmployeeAddressRepository EmployeeAddressRepository { get; }
        IGenericRepository<EmployeeType> EmployeeTypeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IGenericRepository<Designation> DesignationRepository { get; }
        ICredentialRepository CredentialRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }

        Task<int> CommitAsync();
    }
}

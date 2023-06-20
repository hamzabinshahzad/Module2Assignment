using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IEmployeeAddressRepository : IGenericRepository<EmployeeAddress>
    {
        IQueryable GetAddressesByEmpId(int empId);
    }
}

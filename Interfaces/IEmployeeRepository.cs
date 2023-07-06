using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IQueryable GetEmployeeDetailsById(int id);

        IQueryable GetAddressById(int id);

        IQueryable GetContactDetailsById(int id);

        IQueryable GetEmployeeDetailsByEmail(string emailAddress);

        IEnumerable<string> GetAllEmployeeNames();
    }
}

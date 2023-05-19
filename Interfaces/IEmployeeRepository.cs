using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IQueryable GetEmployeeDetailsById(int id);
    }
}

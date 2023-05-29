using ModuleAssignment.Models;

namespace ModuleAssignment.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        int NumberOfEmployeesInDepartment(int id);

        IQueryable NumberOfEmployeesInAllDepartments();
    }
}

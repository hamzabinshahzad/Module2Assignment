using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly EmployeeDbContext Context;

        public DepartmentRepository(EmployeeDbContext IncomingContext) : base(IncomingContext)
        {
            Context = IncomingContext;
        }

    }
}

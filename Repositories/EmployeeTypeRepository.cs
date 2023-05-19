using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class EmployeeTypeRepository : GenericRepository<EmployeeType>, IEmployeeTypeRepository
    {
        private readonly EmployeeDbContext Context;

        public EmployeeTypeRepository(EmployeeDbContext IncomingContext) : base(IncomingContext)
        {
            Context = IncomingContext;
        }   


    }
}

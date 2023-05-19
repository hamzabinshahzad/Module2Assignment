using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        private readonly EmployeeDbContext Context;

        public DesignationRepository(EmployeeDbContext IncomingContext) : base(IncomingContext)
        {
            Context = IncomingContext;
        }


    }
}

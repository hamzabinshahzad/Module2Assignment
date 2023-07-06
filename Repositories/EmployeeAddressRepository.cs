using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class EmployeeAddressRepository : GenericRepository<EmployeeAddress>, IEmployeeAddressRepository
    {
        private readonly EmployeeDbContext Context;

        public EmployeeAddressRepository(EmployeeDbContext IncomingContext) : base(IncomingContext)
        {
            Context = IncomingContext;
        }


        public IQueryable GetAddressesByEmpId(int empId)
        {
            var EmpAllAddr = Context.EmployeeAddresses
                .Where(addr => addr.EmployeeId == empId);
            return EmpAllAddr;
        }


    }
}

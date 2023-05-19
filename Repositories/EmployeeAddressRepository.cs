using Microsoft.AspNetCore.Razor.TagHelpers;
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


    }
}

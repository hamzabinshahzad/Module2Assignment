using ModuleAssignment.Models;
using ModuleAssignment.Services;

namespace ModuleAssignment.Data
{
    public class Query
    {
        private readonly IUnitofWork _UnitOfWork;

        public Query(IUnitofWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public IQueryable<Employee> GetEmployees()
        { 
            return _UnitOfWork.EmployeeRepository.GetAll().AsQueryable();
        }

    }
}

using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;


namespace ModuleAssignment.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly EmployeeDbContext Context;

        private readonly IGenericRepository<Employee> _EmployeeRepository;
        private readonly IGenericRepository<EmployeeAddress> _EmployeeAddressRepository;
        private readonly IGenericRepository<EmployeeType> _EmployeeTypeRepository;
        private readonly IGenericRepository<Department> _DepartmentRepository;
        private readonly IGenericRepository<Designation> _DesignationRepository;


        public UnitofWork(
            EmployeeDbContext IncomingContext,
            IGenericRepository<Employee> employeeRepository, IGenericRepository<EmployeeAddress> employeeAddressRepository,
            IGenericRepository<EmployeeType> employeeTypeRepository, IGenericRepository<Department> departmentRepository, 
            IGenericRepository<Designation> designationRepository
        )
        {
            this.Context = IncomingContext;
            _EmployeeRepository = employeeRepository;
            _EmployeeAddressRepository = employeeAddressRepository;
            _EmployeeTypeRepository = employeeTypeRepository;
            _DepartmentRepository = departmentRepository;
            _DesignationRepository = designationRepository;
        }


        public IGenericRepository<Employee> EmployeeRepository => _EmployeeRepository;
        public IGenericRepository<EmployeeAddress> EmployeeAddressRepository => _EmployeeAddressRepository;
        public IGenericRepository<EmployeeType> EmployeeTypeRepository => _EmployeeTypeRepository;
        public IGenericRepository<Department> DepartmentRepository => _DepartmentRepository;
        public IGenericRepository<Designation> DesignationRepository => _DesignationRepository;


        public void Commit()
        {
            Context.SaveChanges();   
        }


        public void Dispose()
        {
            Context.Dispose();
        }


    }
}

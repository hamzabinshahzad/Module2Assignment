using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;


namespace ModuleAssignment.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly EmployeeDbContext Context;

        //private readonly IGenericRepository<Employee> _EmployeeRepository;
        //private readonly IGenericRepository<EmployeeAddress> _EmployeeAddressRepository;
        //private readonly IGenericRepository<EmployeeType> _EmployeeTypeRepository;
        //private readonly IGenericRepository<Department> _DepartmentRepository;
        //private readonly IGenericRepository<Designation> _DesignationRepository;
        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IEmployeeAddressRepository EmployeeAddressRepository { get; private set; }
        public IEmployeeTypeRepository EmployeeTypeRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IDesignationRepository DesignationRepository { get; private set; }

        public UnitofWork(
            EmployeeDbContext IncomingContext,
            IEmployeeRepository employeeRepository, IEmployeeAddressRepository employeeAddressRepository,
            IEmployeeTypeRepository employeeTypeRepository, IDepartmentRepository departmentRepository, 
            IDesignationRepository designationRepository
        )
        {
            Context = IncomingContext;
            EmployeeRepository = employeeRepository;
            EmployeeAddressRepository = employeeAddressRepository;
            EmployeeTypeRepository = employeeTypeRepository;
            DepartmentRepository = departmentRepository;
            DesignationRepository = designationRepository;
        }


        //public IGenericRepository<Employee> EmployeeRepository => _EmployeeRepository;
        //public IGenericRepository<EmployeeAddress> EmployeeAddressRepository => _EmployeeAddressRepository;
        //public IGenericRepository<EmployeeType> EmployeeTypeRepository => _EmployeeTypeRepository;
        //public IGenericRepository<Department> DepartmentRepository => _DepartmentRepository;
        //public IGenericRepository<Designation> DesignationRepository => _DesignationRepository;


        public void Commit()
        {
            Context.SaveChanges();   
        }


    }
}

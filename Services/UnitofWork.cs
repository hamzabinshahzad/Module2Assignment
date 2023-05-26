using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;


namespace ModuleAssignment.Services
{
    public class UnitofWork : IUnitofWork
    {
        private readonly EmployeeDbContext Context;


        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IGenericRepository<EmployeeAddress> EmployeeAddressRepository { get; private set; }
        public IGenericRepository<EmployeeType> EmployeeTypeRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IGenericRepository<Designation> DesignationRepository { get; private set; }


        public UnitofWork(
            EmployeeDbContext IncomingContext,
            IEmployeeRepository employeeRepository, IGenericRepository<EmployeeAddress> employeeAddressRepository,
            IGenericRepository<EmployeeType> employeeTypeRepository, IDepartmentRepository departmentRepository,
            IGenericRepository<Designation> designationRepository
        )
        {
            Context = IncomingContext;
            EmployeeRepository = employeeRepository;
            EmployeeAddressRepository = employeeAddressRepository;
            EmployeeTypeRepository = employeeTypeRepository;
            DepartmentRepository = departmentRepository;
            DesignationRepository = designationRepository;
        }


        public void Commit()
        {
            Context.SaveChanges();
        }


    }
}

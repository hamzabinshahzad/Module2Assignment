using ModuleAssignment.Interfaces;

namespace ModuleAssignment.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();

        public IEmployeeAddressRepository EmployeeAddressRepository => throw new NotImplementedException();

        public IEmployeeTypeRepository EmployeeTypeRepository => throw new NotImplementedException();

        public IDepartmentRepository DepartmentRepository => throw new NotImplementedException();

        public IDesignationRepository DesignationRepository => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

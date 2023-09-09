using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;
using System.Data;

namespace ModuleAssignment.Services
{
    public class UnitofWork : IUnitofWork
    {
        private readonly EmployeeDbContext Context;


        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IEmployeeAddressRepository EmployeeAddressRepository { get; private set; }
        public IGenericRepository<EmployeeType> EmployeeTypeRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IGenericRepository<Designation> DesignationRepository { get; private set; }
        public ICredentialRepository CredentialRepository { get; private set; }
        public IRefreshTokenRepository RefreshTokenRepository { get; private set; }


        public UnitofWork(
            EmployeeDbContext IncomingContext,
            IEmployeeRepository employeeRepository, IEmployeeAddressRepository employeeAddressRepository,
            IGenericRepository<EmployeeType> employeeTypeRepository, IDepartmentRepository departmentRepository,
            IGenericRepository<Designation> designationRepository, ICredentialRepository credentialRepository,
            IRefreshTokenRepository refreshTokenRepository
        )
        {
            Context = IncomingContext;
            EmployeeRepository = employeeRepository;
            EmployeeAddressRepository = employeeAddressRepository;
            EmployeeTypeRepository = employeeTypeRepository;
            DepartmentRepository = departmentRepository;
            DesignationRepository = designationRepository;
            CredentialRepository = credentialRepository;
            RefreshTokenRepository = refreshTokenRepository;
        }


        public async Task<int> CommitAsync()
        {
            try
            { 
                int entries = await Context.SaveChangesAsync();
                Console.WriteLine($"DB_IO: Entries written: {entries}");
                return entries;
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine($"ERROR: Unable to save changes to DB => {e.Message}");
                return 0;
            }
            catch(DBConcurrencyException e)
            {
                Console.WriteLine($"ERROR: Unable to perform CRUD in DB => {e.Message}");
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                return 0;
            }
        }


    }
}

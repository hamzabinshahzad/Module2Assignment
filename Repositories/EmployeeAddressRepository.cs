using Microsoft.EntityFrameworkCore;
using ModuleAssignment.Data;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Repositories
{
    public class EmployeeAddressRepository : IEmployeeAddressRepository
    {
        private readonly DbSet<EmployeeAddress> DbSet;

        public EmployeeAddressRepository(AppDbContext IncomingContext)
        {
            this.DbSet = IncomingContext.Set<EmployeeAddress>();
        }


        public void Add(EmployeeAddress address)
        {
            DbSet.Add(address);
        }


        public void Delete(int id)
        {
            var Address = DbSet.Find(id);
            if (Address != null) DbSet.Remove(Address);
        }


        public IEnumerable<EmployeeAddress> GetAll()
        {
            var Addresses = DbSet.ToList();
            if (Addresses != null) return Addresses;
            else return null;
        }


        public EmployeeAddress GetById(int id)
        {
            var Address = DbSet.Find(id);
            if (Address != null) return Address;
            else return null;
        }

        public void Update(EmployeeAddress address)
        {
            if(address.Id > 0) DbSet.Update(address);
        }


    }
}

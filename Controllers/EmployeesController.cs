using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Models;
using ModuleAssignment.Repositories;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : GenericController<Employee>
    {
        private readonly IUnitofWork _UnitOfWork;

        public EmployeesController(IUnitofWork unitofWork) : base(unitofWork)
        {
            _UnitOfWork = unitofWork;
        }


        [HttpGet]
        public IActionResult GetEmployeeAddressById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetAddressById(id));
        }


        [HttpGet]
        public IActionResult GetEmployeeDetailsByEmail(string emailAddress)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsByEmail(emailAddress));
        }


    }
}

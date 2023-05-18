using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;
using ModuleAssignment.Repositories;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;

        public EmployeesController(IUnitofWork unitofWork)
        {
            this._UnitOfWork = unitofWork;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetAll());
        }

        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            _UnitOfWork.EmployeeRepository.Add(employee);
        }
    }
}

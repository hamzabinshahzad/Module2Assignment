using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Models;
using ModuleAssignment.Repositories;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;

        public EmployeesController(IUnitofWork unitofWork)
        {
            _UnitOfWork = unitofWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetAll());
            
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetById(id));
        }


        [HttpGet]
        public IActionResult GetDetailsById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsById(id));   
        }


        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            _UnitOfWork.EmployeeRepository.Add(employee);
            _UnitOfWork.Commit();
            return Ok(employee);
        }


        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            _UnitOfWork.EmployeeRepository.Update(employee);
            _UnitOfWork.Commit();
            return Ok(employee);
        }


        [HttpDelete]
        public IActionResult Remove(int id) 
        {
            _UnitOfWork.EmployeeRepository.Delete(id);
            _UnitOfWork.Commit();
            return Ok($"Employee with id: {id} has been deleted successfully!");
        }


    }
}

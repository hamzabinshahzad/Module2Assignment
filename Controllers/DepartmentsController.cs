using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitofWork _UnitofWork;

        public DepartmentsController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitofWork.DepartmentRepository.GetAll());
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitofWork.EmployeeRepository.GetById(id));
        }


        [HttpPost]
        public IActionResult Add(Department department)
        {
            _UnitofWork.DepartmentRepository.Add(department);
            _UnitofWork.Commit();
            return Ok(department);
        }


        [HttpPost]
        public IActionResult Update(Department department) 
        {
            _UnitofWork.DepartmentRepository.Update(department);
            _UnitofWork.Commit();
            return Ok(department);
        }


        [HttpPost]
        public IActionResult Remove(int id)
        {
            _UnitofWork.DepartmentRepository.Delete(id);
            _UnitofWork.Commit();
            return Ok($"Department with id: {id} has been deleted successfully!");
        }


    }
}

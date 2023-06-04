using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeTypesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;

        public EmployeeTypesController(IUnitofWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitOfWork.EmployeeTypeRepository.GetAll());
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.EmployeeTypeRepository.GetById(id));
        }


        [HttpPost]
        [ArgumentCountFilter]
        public IActionResult Add(EmployeeType employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Add(employeeType);
            if (_UnitOfWork.Commit() > 0) return Ok(employeeType);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        public IActionResult Update(EmployeeType employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Update(employeeType);
            if (_UnitOfWork.Commit() > 0) return Ok(employeeType);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.EmployeeTypeRepository.Delete(id);
            if(_UnitOfWork.Commit() > 0) return Ok($"Employee Type with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }


    }
}

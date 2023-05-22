using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.EmployeeTypeRepository.GetById(id));
        }


        [HttpPost]
        public IActionResult Add(EmployeeType employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Add(employeeType);
            _UnitOfWork.Commit();
            return Ok(employeeType);
        }


        [HttpPut]
        public IActionResult Update(EmployeeType employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Update(employeeType);
            _UnitOfWork.Commit();
            return Ok(employeeType);
        }


        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.EmployeeTypeRepository.Delete(id);
            _UnitOfWork.Commit();
            return Ok($"Employee Type with id: {id} has been deleted successfully.");
        }


    }
}

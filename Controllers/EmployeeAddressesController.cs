using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Models;
using ModuleAssignment.Services;
using System.Net;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAddressesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;

        public EmployeeAddressesController(IUnitofWork unitofWork)
        {
            _UnitOfWork = unitofWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitOfWork.EmployeeAddressRepository.GetAll());
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.EmployeeAddressRepository.GetById(id));
        }


        [HttpPost]
        public IActionResult Add(EmployeeAddress address)
        {
            _UnitOfWork.EmployeeAddressRepository.Add(address);
            if (_UnitOfWork.Commit() > 0) return Ok(address);
            else return StatusCode(500);
        }


        [HttpPut]
        public IActionResult Update(EmployeeAddress address)
        {
            _UnitOfWork.EmployeeAddressRepository.Update(address);
            if (_UnitOfWork.Commit() > 0) return Ok(address);
            else return StatusCode(500);
        }


        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.EmployeeAddressRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Address with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }


    }
}

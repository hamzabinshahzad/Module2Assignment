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
        private readonly IUnitofWork _UnitofWork;

        public EmployeeAddressesController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitofWork.EmployeeAddressRepository.GetAll());
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitofWork.EmployeeAddressRepository.GetById(id));
        }


        [HttpPost]
        public IActionResult Add(EmployeeAddress address)
        {
            _UnitofWork.EmployeeAddressRepository.Add(address);
            _UnitofWork.Commit();
            return Ok(address);
        }


        [HttpPut]
        public IActionResult Update(EmployeeAddress address)
        {
            _UnitofWork.EmployeeAddressRepository.Update(address);
            _UnitofWork.Commit();
            return Ok(address);
        }


        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _UnitofWork.EmployeeAddressRepository.Delete(id);
            _UnitofWork.Commit();
            return Ok($"Address with id: {id} has been deleted successfully!");
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Services;
using System.Net;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;

        public DesignationsController(IUnitofWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitOfWork.DesignationRepository.GetAll());
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.DesignationRepository.GetById(id));
        }


        [HttpPost]
        [ArgumentCountFilter]
        public IActionResult Add(Designation designation)
        {
            _UnitOfWork.DesignationRepository.Add(designation);
            if (_UnitOfWork.Commit() > 0) return Ok(designation);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        public IActionResult Update(Designation designation)
        {
            _UnitOfWork.DesignationRepository.Update(designation);
            if (_UnitOfWork.Commit() > 0) return Ok(designation);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.DesignationRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Designation with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }


    }
}

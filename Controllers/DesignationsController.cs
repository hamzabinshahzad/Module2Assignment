using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Models;
using ModuleAssignment.Services;

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
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.DesignationRepository.GetById(id));
        }


        [HttpPost]
        public IActionResult Add(Designation designation)
        {
            _UnitOfWork.DesignationRepository.Add(designation);
            _UnitOfWork.Commit();
            return Ok(designation);
        }


        [HttpPut]
        public IActionResult Update(Designation designation)
        {
            _UnitOfWork.DesignationRepository.Update(designation);
            _UnitOfWork.Commit();
            return Ok(designation);
        }


        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.DesignationRepository.Delete(id);
            _UnitOfWork.Commit();
            return Ok($"Designation with id: {id} has been deleted successfully.");
        }

    }
}

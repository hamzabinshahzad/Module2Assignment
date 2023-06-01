using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Models;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IUnitofWork<T> _UnitOfWork;

        public GenericController(IUnitofWork<T> unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitOfWork.GenericRepository.GetAll());
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitOfWork.GenericRepository.GetById(id));
        }


        [HttpPost]
        public IActionResult Add(T entity)
        {
            _UnitOfWork.GenericRepository.Add(entity);
            if (_UnitOfWork.Commit() > 0) return Ok(entity);
            else return StatusCode(500);
        }


        [HttpPut]
        public IActionResult Update(T entity)
        {
            _UnitOfWork.GenericRepository.Update(entity);
            if (_UnitOfWork.Commit() > 0) return Ok(entity);
            else return StatusCode(500);
        }


        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.GenericRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Designation with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }
    }
}

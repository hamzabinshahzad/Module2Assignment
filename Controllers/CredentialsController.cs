using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/authentication/[action]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IUnitofWork _UnitofWork;


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitofWork.CredentialRepository.GetById(id));
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_UnitofWork.CredentialRepository.GetAll());
        }


        [HttpPost]
        public IActionResult Add(Models.Credential credential)
        {
            _UnitofWork.CredentialRepository.Add(credential);
            if (_UnitofWork.Commit() > 0) return Ok(credential);
            else return StatusCode(500);
        }


        [HttpPut]
        public IActionResult Update(Models.Credential credential)
        {
            _UnitofWork.CredentialRepository.Update(credential);
            if(_UnitofWork.Commit() > 0) return Ok(credential);
            else return StatusCode(500);
        }


        [HttpDelete]
        public IActionResult Remove(int id)
        {
            _UnitofWork.CredentialRepository.Delete(id);
            if (_UnitofWork.Commit() > 0) return Ok($"Credential with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }
    
    
    }
}

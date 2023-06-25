using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.DTOs;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Services;


namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitofWork _UnitofWork;
        private readonly IMapper _Mapper;

        public AuthenticationController(IUnitofWork unitofwork, IMapper mapper)
        {
            _UnitofWork = unitofwork;
            _Mapper = mapper;
        }


        [HttpPost]
        [ArgumentCountFilter]
        [AllowAnonymous]
        public IActionResult SignIn(SignInDTO credential)
        {
            var ReqCred = _UnitofWork.CredentialRepository.CheckCredentials(_Mapper.Map<Credential>(credential));
            if (ReqCred != null) return Ok(_UnitofWork.CredentialRepository.GenerateToken(ReqCred));
            else return StatusCode(403, "Invalid username or password!");
        }


        [HttpGet]
        public IActionResult GetSelf()
        {
            string Id = HttpContext.User.FindFirst("id").Value;
            if (Id != null) return Ok(_UnitofWork.CredentialRepository.GetById(int.Parse(Id)));
            else return StatusCode(403, "Access Denied.");
        }


        [HttpPost]
        [ArgumentCountFilter]
        public async Task<IActionResult> PasswordUpdate(PasswordDTO dto)
        {
            var User = HttpContext.User;
            string Id = User.FindFirst("id").Value;
            if (Id != null)
            {
                if (_UnitofWork.CredentialRepository.ReplacePassword(int.Parse(Id), dto.Password))
                {
                    if (await _UnitofWork.CommitAsync() > 0) return Ok("Password updated successfully.");
                    else return StatusCode(500);
                }
                else return StatusCode(400);
            }
            else return StatusCode(403, "Access Denied");
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            Credential Cred = _UnitofWork.CredentialRepository.GetById(id);
            return Ok(_Mapper.Map<CredentialDTO>(Cred));
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            var AllCreds = _UnitofWork.CredentialRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<Credential>, IEnumerable<CredentialDTO>>(AllCreds));
        }


        [HttpPost]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(Credential credential)
        {
            if (!_UnitofWork.CredentialRepository.UsernameExists(credential.Username))
            {
                _UnitofWork.CredentialRepository.Add(credential);
                if (await _UnitofWork.CommitAsync() > 0) return Ok(credential);
                else return StatusCode(500);
            }
            else return BadRequest("Please provide a different username!");
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(CredentialDTO credential)
        {
            _UnitofWork.CredentialRepository.Update(_Mapper.Map<Credential>(credential));
            if(await _UnitofWork.CommitAsync() > 0) return Ok(credential);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remove(int id)
        {
            _UnitofWork.CredentialRepository.Delete(id);
            if (await _UnitofWork.CommitAsync() > 0) return Ok($"Credential with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }
    
    
    }
}

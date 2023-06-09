using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Microsoft.IdentityModel.Tokens;
using ModuleAssignment.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModuleAssignment.Controllers
{
    [Route("api/authentication/[action]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IUnitofWork _UnitofWork;
        private readonly IConfiguration _Config;

        public CredentialsController(IUnitofWork unitofwork, IConfiguration config)
        {
            _UnitofWork = unitofwork;
            _Config = config;
        }


        private string GenerateToken(Credential credential) 
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["JwtSettings:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var NewToken = new JwtSecurityToken(
                _Config["JwtSettings:Issuer"],
                _Config["JwtSettings:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(NewToken);
        }



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

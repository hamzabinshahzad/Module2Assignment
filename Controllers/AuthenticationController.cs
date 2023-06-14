﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.DTOs;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Filters.AuthorizationFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/authentication/[action]")]
    [ApiController]
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
        public IActionResult SignIn(CredentialDTO credential)
        {
            var ReqCred = _UnitofWork.CredentialRepository.CheckCredentials(_Mapper.Map<Credential>(credential));
            if (ReqCred != null) return Ok(new { token = _UnitofWork.CredentialRepository.GenerateToken(ReqCred) });
            else return StatusCode(403, "Invalid username or password!");
        }


        // FOR TESTING ONLY
        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("This now works because the token was provided in request HEADER!");
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize]
        [SelfAccessFilter("user")]
        public IActionResult GetById(int id)
        {
            return Ok(_UnitofWork.CredentialRepository.GetById(id));
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            return Ok(_UnitofWork.CredentialRepository.GetAll());
        }


        [HttpPost]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Credential credential)
        {
            _UnitofWork.CredentialRepository.Add(credential);
            if (_UnitofWork.Commit() > 0) return Ok(credential);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Update(Credential credential)
        {
            _UnitofWork.CredentialRepository.Update(credential);
            if(_UnitofWork.Commit() > 0) return Ok(credential);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Remove(int id)
        {
            _UnitofWork.CredentialRepository.Delete(id);
            if (_UnitofWork.Commit() > 0) return Ok($"Credential with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }
    
    
    }
}

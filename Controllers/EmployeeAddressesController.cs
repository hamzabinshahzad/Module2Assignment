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
    public class EmployeeAddressesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public EmployeeAddressesController(IUnitofWork unitofWork, IMapper mapper)
        {
            _UnitOfWork = unitofWork;
            _Mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetSelf()
        {
            var Claim = HttpContext.User.FindFirst("empid");
            if(Claim != null) return Ok(_UnitOfWork.EmployeeAddressRepository.GetAddressesByEmpId(int.Parse(Claim.Value)));
            else return BadRequest();
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetByEmployeeId(int employeeId) 
        {
            return Ok(_UnitOfWork.EmployeeAddressRepository.GetAddressesByEmpId(employeeId));
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            var AllAddresses = _UnitOfWork.EmployeeAddressRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<EmployeeAddress>, IEnumerable<EmployeeAddressDTO>>(AllAddresses));
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            EmployeeAddress EmpAddr = _UnitOfWork.EmployeeAddressRepository.GetById(id);
            return Ok(_Mapper.Map<EmployeeAddress>(EmpAddr));
        }


        [HttpPost]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Add(EmployeeAddress address)
        {
            _UnitOfWork.EmployeeAddressRepository.Add(address);
            if (_UnitOfWork.Commit() > 0) return Ok(address);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Update(EmployeeAddressDTO address)
        {
            _UnitOfWork.EmployeeAddressRepository.Update(_Mapper.Map<EmployeeAddress>(address));
            if (_UnitOfWork.Commit() > 0) return Ok(address);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.EmployeeAddressRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Address with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }


    }
}

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
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public EmployeesController(IUnitofWork unitofWork, IMapper mapper)
        {
            _UnitOfWork = unitofWork;
            _Mapper = mapper;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllEmployeeNames()
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetAllEmployeeNames());   
        }


        [HttpGet]
        public IActionResult GetSelf()
        {
            var Claim = HttpContext.User.FindFirst("empid");
            if (Claim != null) return Ok(_UnitOfWork.EmployeeRepository.GetById(int.Parse(Claim.Value)));
            else return BadRequest();
        }


        [HttpGet]
        public IActionResult GetSelfDetails()
        {
            var Claim = HttpContext.User.FindFirst("empid");
            if (Claim != null) return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsById(int.Parse(Claim.Value)));
            else return BadRequest();
        }


        [HttpGet]
        public IActionResult GetSelfAddress()
        {
            var Claim = HttpContext.User.FindFirst("empid");
            if (Claim != null) return Ok(_UnitOfWork.EmployeeRepository.GetAddressById(int.Parse(Claim.Value)));
            else return BadRequest();
        }


        [HttpGet]
        public IActionResult GetSelfContactDetails()
        {
            var Claim = HttpContext.User.FindFirst("empid");
            if (Claim != null) return Ok(_UnitOfWork.EmployeeRepository.GetContactDetailsById(int.Parse(Claim.Value)));
            else return BadRequest();
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            var AllEmps = _UnitOfWork.EmployeeRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(AllEmps)); 
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            Employee Emp = _UnitOfWork.EmployeeRepository.GetById(id);
            return Ok(_Mapper.Map<EmployeeDTO>(Emp));
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetDetailsById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsById(id));   
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetAddressById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetAddressById(id));
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetContactDetailsById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetContactDetailsById(id));
        }


        [HttpGet]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult GetDetailsByEmail(string emailAddress)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsByEmail(emailAddress));
        }


        [HttpPost]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Add(Employee employee)
        {
            _UnitOfWork.EmployeeRepository.Add(employee);
            if (_UnitOfWork.Commit() > 0) return Ok(employee);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Update(EmployeeDTO employee)
        {
            _UnitOfWork.EmployeeRepository.Update(_Mapper.Map<Employee>(employee));
            if (_UnitOfWork.Commit() > 0) return Ok(employee);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public IActionResult Remove(int id) 
        {
            _UnitOfWork.EmployeeRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Employee with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }


    }
}

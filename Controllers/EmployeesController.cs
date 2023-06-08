using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.DTOs;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Repositories;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
        public IActionResult GetAll()
        {
            var AllEmps = _UnitOfWork.EmployeeRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(AllEmps)); 
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            Employee Emp = _UnitOfWork.EmployeeRepository.GetById(id);
            return Ok(_Mapper.Map<EmployeeDTO>(Emp));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetDetailsById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsById(id));   
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetEmployeeAddressById(int id)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetAddressById(id));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetEmployeeDetailsByEmail(string emailAddress)
        {
            return Ok(_UnitOfWork.EmployeeRepository.GetEmployeeDetailsByEmail(emailAddress));
        }


        [HttpPost]
        [ArgumentCountFilter]
        public IActionResult Add(Employee employee)
        {
            _UnitOfWork.EmployeeRepository.Add(employee);
            if (_UnitOfWork.Commit() > 0) return Ok(employee);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        public IActionResult Update(EmployeeDTO employee)
        {
            _UnitOfWork.EmployeeRepository.Update(_Mapper.Map<Employee>(employee));
            if (_UnitOfWork.Commit() > 0) return Ok(employee);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        public IActionResult Remove(int id) 
        {
            _UnitOfWork.EmployeeRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Employee with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }


    }
}

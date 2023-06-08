using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.DTOs;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Services;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeTypesController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public EmployeeTypesController(IUnitofWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var AllEmpTypes = _UnitOfWork.EmployeeTypeRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<EmployeeType>, IEnumerable<EmployeeTypeDTO>>(AllEmpTypes));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            EmployeeType EmpType = _UnitOfWork.EmployeeTypeRepository.GetById(id);
            return Ok(_Mapper.Map<EmployeeTypeDTO>(EmpType));
        }


        [HttpPost]
        [ArgumentCountFilter]
        public IActionResult Add(EmployeeType employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Add(employeeType);
            if (_UnitOfWork.Commit() > 0) return Ok(employeeType);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        public IActionResult Update(EmployeeTypeDTO employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Update(_Mapper.Map<EmployeeType>(employeeType));
            if (_UnitOfWork.Commit() > 0) return Ok(employeeType);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.EmployeeTypeRepository.Delete(id);
            if(_UnitOfWork.Commit() > 0) return Ok($"Employee Type with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }


    }
}

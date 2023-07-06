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
        [AllowAnonymous]
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(EmployeeType employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Add(employeeType);
            if (await _UnitOfWork.CommitAsync() > 0) return Ok(employeeType);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(EmployeeTypeDTO employeeType)
        {
            _UnitOfWork.EmployeeTypeRepository.Update(_Mapper.Map<EmployeeType>(employeeType));
            if (await _UnitOfWork.CommitAsync() > 0) return Ok(employeeType);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remove(int id)
        {
            _UnitOfWork.EmployeeTypeRepository.Delete(id);
            if(await _UnitOfWork.CommitAsync() > 0) return Ok($"Employee Type with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }


    }
}

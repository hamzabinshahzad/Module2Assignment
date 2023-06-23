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
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitofWork _UnitofWork;
        private readonly IMapper _Mapper;

        public DepartmentsController(IUnitofWork unitofWork, IMapper mapper)
        {
            _UnitofWork = unitofWork;
            _Mapper = mapper;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var AllDepts = _UnitofWork.DepartmentRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(AllDepts));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            Department Dept = _UnitofWork.DepartmentRepository.GetById(id);
            return base.Ok(_Mapper.Map<DepartmentDTO>(Dept));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetTotalEmployeesInDepartment(int id)
        {
            return Ok(_UnitofWork.DepartmentRepository.NumberOfEmployeesInDepartment(id));
        }


        [HttpGet]
        public IActionResult GetTotalEmployees()
        {
            return Ok(_UnitofWork.DepartmentRepository.NumberOfEmployeesInAllDepartments());
        }


        [HttpPost]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Department department)
        {
            _UnitofWork.DepartmentRepository.Add(department);
            if (await _UnitofWork.CommitAsync() > 0) return Ok(department);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DepartmentDTO department) 
        {
            _UnitofWork.DepartmentRepository.Update(_Mapper.Map<Department>(department));
            if (await _UnitofWork.CommitAsync() > 0) return Ok(department);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remove(int id)
        {
            _UnitofWork.DepartmentRepository.Delete(id);
            if (await _UnitofWork.CommitAsync() > 0) return Ok($"Department with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }


    }
}

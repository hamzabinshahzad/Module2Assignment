using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.Interfaces;
using ModuleAssignment.Models;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitofWork _UnitofWork;

        public DepartmentsController(IUnitofWork unitofWork)
        {
            _UnitofWork = unitofWork;
        }

        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return _UnitofWork.DepartmentRepository.GetAll();
        }

        [HttpPost]
        public void AddDepartment(Department department)
        {
            _UnitofWork.DepartmentRepository.Add(department);
            _UnitofWork.Commit();
        }
    }
}

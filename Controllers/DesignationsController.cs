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
    public class DesignationsController : ControllerBase
    {
        private readonly IUnitofWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public DesignationsController(IUnitofWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var AllDesig = _UnitOfWork.DesignationRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<Designation>, IEnumerable<DesignationDTO>>(AllDesig));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            var Desig = _UnitOfWork.DesignationRepository.GetById(id);
            return Ok(_Mapper.Map<DesignationDTO>(Desig));
        }


        [HttpPost]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(Designation designation)
        {
            _UnitOfWork.DesignationRepository.Add(designation);
            if (await _UnitOfWork.CommitAsync() > 0) return Ok(designation);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(DesignationDTO designation)
        {
            _UnitOfWork.DesignationRepository.Update(_Mapper.Map<Designation>(designation));
            if (await _UnitOfWork.CommitAsync() > 0) return Ok(designation);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remove(int id)
        {
            _UnitOfWork.DesignationRepository.Delete(id);
            if (await _UnitOfWork.CommitAsync() > 0) return Ok($"Designation with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }


    }
}

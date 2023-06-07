using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleAssignment.DTOs;
using ModuleAssignment.Filters.ActionFilters;
using ModuleAssignment.Models;
using ModuleAssignment.Services;
using System.Net;

namespace ModuleAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
        public IActionResult GetAll()
        {
            var AllDesig = _UnitOfWork.DesignationRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<Designation>, IEnumerable<Designation>>(AllDesig));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            var Desig = _UnitOfWork.DesignationRepository.GetById(id);
            return Ok(_Mapper.Map<Designation>(Desig));
        }


        [HttpPost]
        [ArgumentCountFilter]
        public IActionResult Add(Designation designation)
        {
            _UnitOfWork.DesignationRepository.Add(designation);
            if (_UnitOfWork.Commit() > 0) return Ok(designation);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        public IActionResult Update(DesignationDTO designation)
        {
            _UnitOfWork.DesignationRepository.Update(_Mapper.Map<Designation>(designation));
            if (_UnitOfWork.Commit() > 0) return Ok(designation);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.DesignationRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Designation with id: {id} has been deleted successfully.");
            else return StatusCode(500);
        }


    }
}

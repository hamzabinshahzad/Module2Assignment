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
        public IActionResult GetAll()
        {
            var AllAddresses = _UnitOfWork.EmployeeAddressRepository.GetAll();
            return Ok(_Mapper.Map<IEnumerable<EmployeeAddress>, IEnumerable<EmployeeAddressDTO>>(AllAddresses));
        }


        [HttpGet]
        [ArgumentCountFilter]
        public IActionResult GetById(int id)
        {
            EmployeeAddress EmpAddr = _UnitOfWork.EmployeeAddressRepository.GetById(id);
            return Ok(_Mapper.Map<EmployeeAddress>(EmpAddr));
        }


        [HttpPost]
        [ArgumentCountFilter]
        public IActionResult Add(EmployeeAddress address)
        {
            _UnitOfWork.EmployeeAddressRepository.Add(address);
            if (_UnitOfWork.Commit() > 0) return Ok(address);
            else return StatusCode(500);
        }


        [HttpPut]
        [ArgumentCountFilter]
        public IActionResult Update(EmployeeAddressDTO address)
        {
            _UnitOfWork.EmployeeAddressRepository.Update(_Mapper.Map<EmployeeAddress>(address));
            if (_UnitOfWork.Commit() > 0) return Ok(address);
            else return StatusCode(500);
        }


        [HttpDelete]
        [ArgumentCountFilter]
        public IActionResult Remove(int id)
        {
            _UnitOfWork.EmployeeAddressRepository.Delete(id);
            if (_UnitOfWork.Commit() > 0) return Ok($"Address with id: {id} has been deleted successfully!");
            else return StatusCode(500);
        }


    }
}

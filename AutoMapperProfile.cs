using AutoMapper;
using ModuleAssignment.DTOs;
using ModuleAssignment.Models;

namespace ModuleAssignment
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Designation, DesignationDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();    
            CreateMap<EmployeeType, EmployeeTypeDTO>().ReverseMap();
            CreateMap<EmployeeAddress, EmployeeAddressDTO>().ReverseMap();
            CreateMap<Credential, SignInDTO>().ReverseMap();
            CreateMap<Credential, PasswordDTO>().ReverseMap();
        }
    }
}

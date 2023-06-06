using AutoMapper;
using ModuleAssignment.DTOs;
using ModuleAssignment.Models;

namespace ModuleAssignment
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SetDepartment, Department>();
            CreateMap<Department, GetDepartment>();
        }
    }
}

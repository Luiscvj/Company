using API.Dtos.EmployeeDTO;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        CreateMap<EmployeeDto,Employee>().ReverseMap();
    }
}
using AutoMapper;
using Company.Data.Entities;
using Company.Services.Interfaces.Department.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Mapping;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Department,DepartmentDto>().ReverseMap();
    }
}

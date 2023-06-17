using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using User.Application.Services.Models;
using User.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace User.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>().ReverseMap();
        }
    }
}

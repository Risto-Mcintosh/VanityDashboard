using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;
using VanityDashboard.Data.Dto;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Web.Profiles
{
    public class VanityComponentProfile : Profile
    {
        public VanityComponentProfile()
        {
            CreateMap<Table, VanityComponentDto>()
                .ReverseMap();
            CreateMap<Mirror, VanityComponentDto>()
                .ReverseMap();
            CreateMap<BaseMaterial, VanityComponentDto>()
                .ReverseMap();
        }
    }
}

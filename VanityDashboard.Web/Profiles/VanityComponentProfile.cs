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
                .ForMember(dest => dest.Type, opt => opt.MapFrom(o => "Table"))
                .ReverseMap();
            CreateMap<Mirror, VanityComponentDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(o => "Mirror"))
                .ReverseMap();
            CreateMap<BaseMaterial, VanityComponentDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(o => "BaseMaterial"))
                .ReverseMap();
        }
    }
}

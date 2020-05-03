using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Web.Models
{
    public class MirrorProfile : Profile
    {
        public MirrorProfile()
        {
            this.CreateMap<Mirror, MirrorDto>()
                .ReverseMap();
        }
    }
}

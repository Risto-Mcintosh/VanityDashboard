using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Web.Models
{
    public class OrderModel : Profile
    {
        public OrderModel()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.TableSize, opt => opt.MapFrom(src => src.Table.Size))
                .ForMember(dest => dest.MirrorSize, opt => opt.MapFrom(src => src.Mirror.Size))
                .ForMember(dest => dest.VanityColor, opt => opt.MapFrom(src => src.Color))
                .ReverseMap();
        }
    }
}

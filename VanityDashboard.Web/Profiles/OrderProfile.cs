using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Web.Models
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Vanity, VanityDto>()
                .ForPath(dest => dest.TableSize, opt => opt.MapFrom(src => src.Table.Size))
                .ForPath(dest => dest.MirrorSize, opt => opt.MapFrom(src => src.Mirror.Size))
                .ForPath(dest => dest.BaseSize, opt => opt.MapFrom(src => src.BaseMaterial.Size))
                .ForPath(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForPath(dest => dest.OrderedOn, opt => opt.MapFrom(src => src.OrderedOn == null ? (DateTime?)null : src.OrderedOn))
                .ForPath(dest => dest.Meta.CompletedOn, opt => opt.MapFrom(src => src.CompletedOn == null ? null : src.CompletedOn))
                .ForPath(dest => dest.Meta.DueOn, opt => opt.MapFrom(src => src.DueOn == null ? null : src.DueOn))
                .ForPath(dest => dest.Meta.PaidOn, opt => opt.MapFrom(src => src.PaidOn == null ? null : src.PaidOn))
                .ReverseMap();
        }
    }
}

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
                .ForPath(dest => dest.Table.Price, opt => opt.MapFrom(src => src.TablePP))
                .ForPath(dest => dest.Mirror.Price, opt => opt.MapFrom(src => src.MirrorPP))
                .ForPath(dest => dest.BaseMaterial.Price, opt => opt.MapFrom(src => src.BaseMaterialPP))
                .ForPath(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForPath(dest => dest.OrderedOn, opt => opt.MapFrom(src => src.OrderedOn == null ? (DateTime?)null : src.OrderedOn))
                .ForPath(dest => dest.Meta.CompletedOn, opt => opt.MapFrom(src => src.CompletedOn == null ? null : src.CompletedOn))
                .ForPath(dest => dest.Meta.DueOn, opt => opt.MapFrom(src => src.DueOn == null ? null : src.DueOn))
                .ForPath(dest => dest.Meta.PaidOn, opt => opt.MapFrom(src => src.PaidOn == null ? null : src.PaidOn))
                .ForPath(dest => dest.Meta.KanbanColumnName, opt => opt.MapFrom(src => src.KanbanColumn.ColumnName))
                .ForPath(dest => dest.Meta.KanbanColumnColor, opt => opt.MapFrom(src => src.KanbanColumn.Color))
                .ReverseMap();
        }
    }
}

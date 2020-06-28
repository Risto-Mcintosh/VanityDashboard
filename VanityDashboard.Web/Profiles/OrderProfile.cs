using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;
using VanityDashboard.Data.Dto;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Web.Models
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Vanity, VanityDto>()
                .ForPath(dest => dest.Table.Price, opt => opt.MapFrom(src => src.TablePP))
                .ForPath(dest => dest.Table.Size, opt => opt.MapFrom(src => src.Table.Size))
                .ForPath(dest => dest.Mirror.Price, opt => opt.MapFrom(src => src.MirrorPP))
                .ForPath(dest => dest.Mirror.Size, opt => opt.MapFrom(src => src.Mirror.Size))
                .ForPath(dest => dest.BaseMaterial.Price, opt => opt.MapFrom(src => src.BaseMaterialPP))
                .ForPath(dest => dest.BaseMaterial.Size, opt => opt.MapFrom(src => src.BaseMaterial.Size))
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForPath(dest => dest.OrderedOn, opt => opt.MapFrom(src => src.OrderedOn == null ? (DateTime?)null : src.OrderedOn))
                .ForPath(dest => dest.Meta.CompletedOn, opt => opt.MapFrom(src => src.CompletedOn == null ? null : src.CompletedOn))
                .ForPath(dest => dest.Meta.DueOn, opt => opt.MapFrom(src => src.DueOn == null ? null : src.DueOn))
                .ForPath(dest => dest.Meta.PaidOn, opt => opt.MapFrom(src => src.PaidOn == null ? null : src.PaidOn))
                .ForPath(dest => dest.Meta.BuildStatus.Name, opt => opt.MapFrom(src => src.KanbanColumn.ColumnName))
                .ForPath(dest => dest.Meta.BuildStatus.Color, opt => opt.MapFrom(src => src.KanbanColumn.Color))
                .ReverseMap();
        }
    }
}

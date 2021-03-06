﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;
using VanityDashboard.Data.Dto;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Web.Profiles
{
    public class KanbanProfile : Profile
    {
        public KanbanProfile()
        {
            CreateMap<Order, KanbanOrderDto>()
                .ForPath(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForPath(dest => dest.KanbanColumnId, opt => opt.MapFrom(src => src.KanbanColumn.Id))
                .ForPath(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus))
                .ReverseMap();

            CreateMap<KanbanColumn, KanbanColumnDto>()
                .ForPath(dest => dest.ColumnId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
 
            CreateMap<KanbanData, KanbanDataDto>()
                .ForPath(dest => dest.ColumnOrder, opt => opt.MapFrom(src =>src.ColumnOrder.Order));
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data;

namespace VanityDashboard.Web.Models
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            this.CreateMap<Table, TableDto>()
                .ReverseMap();
        }
    }

  
}

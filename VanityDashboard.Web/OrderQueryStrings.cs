using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VanityDashboard.Web.QueryParams
{
    public class OrderQueryStrings
    {
        [FromQuery(Name = "limit")]
        public int Limit { get; set; }
        [FromQuery(Name = "thisweek")]
        public Boolean ThisWeek { get; set; } = false;
        [FromQuery(Name = "orderby")]
        public string OrderBy { get; set; }
    }
}

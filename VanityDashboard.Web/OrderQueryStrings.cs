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
        public int Limit { get; set; } = 15;
    }
}

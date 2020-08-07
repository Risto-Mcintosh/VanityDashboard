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
        public int? Limit { get; set; }
        [FromQuery(Name = "thisWeek")]
        public Boolean ThisWeek { get; set; } = false;
        [FromQuery(Name = "orderBy")]
        public string OrderBy { get; set; }
        [FromQuery(Name = "pageNumber")]
        public int? PageNumber { get; set; }
        [FromQuery(Name = "searchString")]
        public string SearchString { get; set; }
        [FromQuery(Name = "listType")]
        public string ListType { get; set; }
    }
}

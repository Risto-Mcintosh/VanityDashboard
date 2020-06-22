using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data.Dto;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Data
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public VanityDto Vanity { get; set; }
        public decimal Total { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderedOn { get; set; }
        public MetaDto Meta { get; set; }
    }
}

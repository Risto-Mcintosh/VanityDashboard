using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VanityDashboard.Data.Dto;

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
       /* public DateTime? PaidOn { get; set; }
        public DateTime? DueOn { get; set; }
        public DateTime? CompletedOn { get; set; }*/
    }
}

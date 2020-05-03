using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VanityDashboard.Data
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public string VanityColor { get; set; }
        public string MirrorSize { get; set; }
        public string TableSize { get; set; }
        public decimal Total { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime PaidOn { get; set; }
        public DateTime DueOn { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}

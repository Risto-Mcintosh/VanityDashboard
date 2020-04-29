using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityDashboard.Data
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Vanity Vanity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double Total { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime PaidOn { get; set; }
        public DateTime DueOn { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}

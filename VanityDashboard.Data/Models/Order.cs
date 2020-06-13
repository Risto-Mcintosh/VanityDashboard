using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Data
{
    public class Order
    {

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Vanity Vanity { get; set; }
        [Column(TypeName = "varchar")]
        public OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderedOn { get; set; }
#nullable enable
        public KanbanColumn? KanbanColumn { get; set; }
        public DateTime? PaidOn { get; set; }
        public DateTime? DueOn { get; set; }
        public DateTime? CompletedOn { get; set; }
    }
}

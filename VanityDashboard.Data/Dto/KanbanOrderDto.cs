using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Dto
{
    public class KanbanOrderDto
    {
       public string OrderId { get; set; }
       public string CustomerName { get; set; }
       public DateTime DueOn { get; set; }
       public string KanbanColumnId { get; set; }
       public string OrderStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Dto
{
    public class KanbanOrderDto
    {
       public string OrderId { get; set; }
       public string customerName { get; set; }
       public DateTime dueOn { get; set; }
       public string kanbanColumnId { get; set; }
    }
}

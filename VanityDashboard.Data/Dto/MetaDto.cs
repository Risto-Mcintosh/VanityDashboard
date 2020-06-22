using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Dto
{
    public class MetaDto
    {
        public DateTime? PaidOn { get; set; }
        public DateTime? DueOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public string KanbanColumnName { get; set; }
        public string KanbanColumnColor { get; set; }
    }
}

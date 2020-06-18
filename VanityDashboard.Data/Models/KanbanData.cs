using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data.Dto;

namespace VanityDashboard.Data.Models
{
    public class KanbanData
    {
        public Dictionary<int, KanbanColumnDto> Columns { get; set; }
        public Dictionary<int, Order> Orders { get; set; }
        public KanbanColumnOrder ColumnOrder { get; set; }
    }
}

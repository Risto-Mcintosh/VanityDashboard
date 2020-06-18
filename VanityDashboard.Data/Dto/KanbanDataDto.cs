using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Dto
{
    public class KanbanDataDto
    {
        public Dictionary<int, KanbanColumnDto> Columns { get; set; }
        public Dictionary<int, KanbanOrderDto> Orders { get; set; }
        public KanbanColumnOrderDto ColumnOrder { get; set; }
    }
}

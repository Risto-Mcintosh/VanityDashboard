using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Dto
{
    public class KanbanDataDto
    {
        public Dictionary<string, KanbanColumnDto> Columns { get; set; }
        public Dictionary<string, KanbanOrderDto> Orders { get; set; }
        public string[] ColumnOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Data.Dto
{
    public class KanbanColumnDto
    {
        public string ColumnId { get; set; }
        public string ColumnName { get; set; }
        public Boolean ColumnLock { get; set; }
        public Boolean IsCompleteColumn { get; set; }
        public Boolean IsStartColumn { get; set; }
        public string Color { get; set; }
        public List<int> OrderIds { get; set; } = new List<int>();
    }
}

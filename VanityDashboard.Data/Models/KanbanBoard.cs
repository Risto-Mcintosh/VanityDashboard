using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Models
{
    public class KanbanBoard
    {
        public int Id { get; set; }
        public string ColumnName { get; set; }
        public Boolean ColumnLock { get; set; }
        public int ColumnPosition { get; set; }
        public Boolean IsCompleteColumn { get; set; }
        public Boolean IsStartColumn { get; set; }
        public string Color { get; set; }
    }
}

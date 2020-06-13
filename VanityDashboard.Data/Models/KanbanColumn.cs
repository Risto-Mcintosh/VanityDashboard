using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VanityDashboard.Data.Models
{
    public class KanbanColumn
    {
        public int Id { get; set; }
        [Required]
        public string ColumnName { get; set; }
        [DefaultValue(false)]
        public Boolean ColumnLock { get; set; }
        [DefaultValue(false)]
        public Boolean IsCompleteColumn { get; set; }
        [DefaultValue(false)]
        public Boolean IsStartColumn { get; set; }
        public string Color { get; set; }
    }
}

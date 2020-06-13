using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VanityDashboard.Data.Models
{
    public class KanbanColumnOrder
    {
        [Key]
        [DefaultValue(1)]
        public int Id { get; set; }
        public string[] Order { get; set; } 
    }
}

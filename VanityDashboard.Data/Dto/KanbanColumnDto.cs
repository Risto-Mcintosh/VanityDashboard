using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Data.Dto
{
    public class KanbanColumnDto : KanbanColumn
    {
        public List<int> OrderIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace VanityDashboard.Data.Dto
{
    public class BuildStatus
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public class MetaDto
    {
        public DateTime? PaidOn { get; set; }
        public DateTime? DueOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public BuildStatus BuildStatus { get; set; }
    }
}

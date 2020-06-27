using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data.Dto;

namespace VanityDashboard.Data
{
    public class VanityDto
    {
        public string Color { get; set; }
        public VanityComponentDto BaseMaterial { get; set; }
        public VanityComponentDto Mirror { get; set; }
        public VanityComponentDto Table { get; set; }
    }
}

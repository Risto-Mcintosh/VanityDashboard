using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data.Dto;

namespace VanityDashboard.Data
{
    public class CompoentDto
    {
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
    public class VanityDto
    {
        public string Color { get; set; }
        public CompoentDto BaseMaterial { get; set; }
        public CompoentDto Mirror { get; set; }
        public CompoentDto Table { get; set; }
    }
}

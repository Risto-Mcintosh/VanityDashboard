using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VanityDashboard.Data.Models
{
    public class VanityComponent
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
}

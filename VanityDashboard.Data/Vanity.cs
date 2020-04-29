using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityDashboard.Data
{
   public class Vanity
    {
        public int Id { get; set; }
        [Required]
        public VanityColor Color {get; set; }
        [Required]
        public Mirror Mirror { get; set; }
        [Required]
        public Table Table { get; set; }
    }
}

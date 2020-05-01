using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanityDashboard.Data
{
   public class Vanity
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public VanityColor Color {get; set; }
        [Required]
        public Mirror Mirror { get; set; }
        [Required]
        public Table Table { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace VanityDashboard.Data
{
    public class Table
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public Sizes Size { get; set; }
        public decimal Price { get; set; }
    }
}

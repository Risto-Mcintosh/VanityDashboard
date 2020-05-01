using System.ComponentModel.DataAnnotations.Schema;

namespace VanityDashboard.Data
{
    public class Mirror
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public Sizes Size { get; set; }
        public decimal Price { get; set; }
    }
}

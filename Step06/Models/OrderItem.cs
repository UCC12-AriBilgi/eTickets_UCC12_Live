using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    // 57
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public int MovieId { get; set; }

        // Relation 
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        // 58
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } // Orders tablosuna referans veriyoruz
    }
}

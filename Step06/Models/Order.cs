using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    // 57
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        //58
        public List<OrderItem> OrderItems { get; set; } //OrderItems tablosuna referans veriyoruz

    }
}

using System.ComponentModel.DataAnnotations;
namespace eTickets.Models
{
    public class ShoppingCartItem
    {
        // 61

        [Key]
        public int Id { get; set; }


        public Movie Movie { get; set; }

        public int Amout { get; set; }

        public string ShoppingCartId { get; set; }

    }
}

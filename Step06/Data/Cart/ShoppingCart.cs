using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        // 64
        // Burası VT ile uğraşacak. Dolayısı ile AppDbContext yapısı yerleştirelim

        public AppDbContext _context {  get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }


        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        // ShoppingCart içinde bulunan itemları getiren metot.

        public List<ShoppingCartItem> GetShoppingCartItems() 
        {
            // LINQ sorgusu ile
            return ShoppingCartItems ??
                (ShoppingCartItems = _context.ShoppingCartItems
                                            .Where(c => c.ShoppingCartId == ShoppingCartId)
                                            .Include(m => m.Movie) //join gibi düşünebiliriz
                                            .ToList());
        
        }

        // ShoppingCart ın toplamını getirecek olan metot
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Movie.Price * c.Amout) // bir filme kac adet bilet almışım
                .Sum();

            return total;
        }
    }
}

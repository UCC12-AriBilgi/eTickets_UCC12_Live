using eTickets.Data.Cart;
using eTickets.Data.Interfaces;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        //65
        // Burada hazır varolan IMovieService yapısını kullanalım

        private readonly IMoviesService _moviesService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
        }

        public IActionResult ShoppingCart()
        {
            // benim ekranda göstereceğim cart itemlarını almam lazım.

            var items=_shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems= items;

            // Hazırlamış olduğumuz kendi ShoppingCartVM üzerine bu bilgileri alalım

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };

            return View(response);
        }
    }
}

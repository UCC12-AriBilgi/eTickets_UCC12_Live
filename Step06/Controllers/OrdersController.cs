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
        // 72
        private readonly IOrdersService _ordersService;

        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _moviesService = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService; // 72
        }

        // 74
        public async Task<IActionResult> Index() 
        {
            string userId = "";
            string userRole = "";

            var orders=await _ordersService.GetOrdersByUserIdAndRoleAsyncs(userId, userRole);

            return View(orders);
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

        // 69
        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            // Hangi movie ile ilgili Order yapıldığını anlamak için
            var item=await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction("ShoppingCart");
        }

        // 70
        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _moviesService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction("ShoppingCart");
        }

        // 73
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems(); // Cart da neler var gelcek

            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

            // VT tarafına gönderdikten sonra sepeti boşaltalım...

            await _shoppingCart.ClearShoppinCartAsync();

            return View("OrderCompleted");
        }


    }
}

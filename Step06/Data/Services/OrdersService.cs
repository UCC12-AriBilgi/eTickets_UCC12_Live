using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class OrdersService : IOrdersService
    {
        // 72

        public readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsyncs(string userId, string userRole)
        {
            // Kullanıcı Id ve Rolune göre kayıt getirecek metot

            var orders=await _context.Orders
                .Include(o=> o.OrderItems)
                .ThenInclude(o=> o.Movie)
                .Where(o=> o.UserId== userId)
                .ToListAsync();


            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            // ShoppingCart tarafındakileri VT tarafına gönderme

            // Sipariş kaydı oluşturuluyor.(Master kayıt)
            var order = new Order
            {
                UserId = userId,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    Price = item.Movie.Price,
                    OrderId = order.Id
                };

                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}

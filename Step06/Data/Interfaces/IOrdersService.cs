using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IOrdersService
    {
        // 72

        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<Order>> GetOrdersByUserIdAndRoleAsyncs(string userId, string userRole);
    }
}

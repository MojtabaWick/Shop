using Shop.Domain.Core.OrderAgg.Entities;

namespace Shop.Domain.Core.OrderAgg.Contracts
{
    public interface IOrderRepository
    {
        public Task<int> CreateOrderFromCart(int userId);

        public Task<Order?> GetOrderById(int orderId);

        public Task<decimal> GetOrderTotalPrice(int orderId);

        public Task<bool> PayOrder(int orderId);
    }
}
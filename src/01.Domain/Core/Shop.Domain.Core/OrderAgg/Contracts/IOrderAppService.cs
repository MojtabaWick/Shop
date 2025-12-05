using Shop.Domain.Core._Common;
using Shop.Domain.Core.OrderAgg.Entities;

namespace Shop.Domain.Core.OrderAgg.Contracts
{
    public interface IOrderAppService
    {
        public Task<int> CreateOrderFromCart(int userId);

        public Task<Order> GetOrderById(int orderId);

        public Task<Result<bool>> PayOrder(int orderId, int userId);
    }
}
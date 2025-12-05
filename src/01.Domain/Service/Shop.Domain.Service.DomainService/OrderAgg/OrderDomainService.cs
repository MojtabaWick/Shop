using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Entities;

namespace Shop.Domain.Service.DomainService.OrderAgg
{
    public class OrderDomainService(IOrderRepository orderRepository) : IOrderDomainService
    {
        public async Task<int> CreateOrderFromCart(int userId)
        {
            return await orderRepository.CreateOrderFromCart(userId);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await orderRepository.GetOrderById(orderId);
        }

        public Task<decimal> GetOrderTotalPrice(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PayOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
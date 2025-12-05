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

        public async Task<decimal> GetOrderTotalPrice(int orderId)
        {
            return await orderRepository.GetOrderTotalPrice(orderId);
        }

        public async Task<bool> PayOrder(int orderId)
        {
            return await orderRepository.PayOrder(orderId);
        }
    }
}
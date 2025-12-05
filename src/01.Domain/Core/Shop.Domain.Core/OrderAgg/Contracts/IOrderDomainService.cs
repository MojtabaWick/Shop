using Shop.Domain.Core._Common;
using Shop.Domain.Core.OrderAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Core.OrderAgg.Contracts
{
    public interface IOrderDomainService
    {
        public Task<int> CreateOrderFromCart(int userId);

        public Task<Order> GetOrderById(int orderId);

        public Task<decimal> GetOrderTotalPrice(int orderId);

        public Task<bool> PayOrder(int orderId);
    }
}
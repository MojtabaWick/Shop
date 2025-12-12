using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.Enums;
using Shop.Domain.Core.OrderAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Dtos;
using Shop.Infrastructure.EFCore.Persistence;

namespace Shop.Infrastructure.EFCore.Repositories.OrderAgg
{
    public class OrderRepository(AppDbContext dbContext) : IOrderRepository
    {
        public async Task<int> CreateOrderFromCart(int userId)
        {
            var cartItems = await dbContext.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return 0;
            }

            var order = new Order
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                TotalPrice = cartItems.Sum(ci => ci.Quantity * ci.Product.Price),
                Items = cartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    UnitPrice = ci.Product.Price,
                    Quantity = ci.Quantity,
                }).ToList()
            };

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            dbContext.CartItems.RemoveRange(cartItems);
            await dbContext.SaveChangesAsync();

            return order.Id;
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await dbContext.Orders
                .AsNoTracking()
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<decimal> GetOrderTotalPrice(int orderId)
        {
            return await dbContext.Orders
                .AsNoTracking()
                .Where(o => o.Id == orderId)
                .Select(o => o.TotalPrice)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> PayOrder(int orderId)
        {
            var updated = await dbContext.Orders
                .Where(o => o.Id == orderId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(o => o.Status, OrderStatus.Paid)
                );

            return updated == 1;
        }

        public async Task<OrderDetailDto> GetOrderWithDetailById(int id)
        {
            var order = await dbContext.Orders
                .Where(o => o.Id == id)
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .AsNoTracking()
                .Select(o => new OrderDetailDto
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    UserFullName = o.User.FullName,
                    Status = o.Status,
                    TotalPrice = o.TotalPrice,
                    OrderItems = o.Items.Select(i => new OrderItemDetail
                    {
                        ProductName = i.Product.Title,
                        UnitPrice = i.UnitPrice,
                        Quantity = i.Quantity
                    }).ToList()
                })
                .FirstOrDefaultAsync();
            return order ?? throw new Exception($"Order with Id : {id} not found.");
        }

        public async Task<List<OrderSummeryDto>> GetAllOrdersAsync()
        {
            return await dbContext.Orders.AsNoTracking().Select(o => new OrderSummeryDto()
            {
                Id = o.Id,
                UserFullName = o.User.FullName,
                UserId = o.UserId,
                TotalPrice = o.TotalPrice,
                Status = o.Status,
            }).ToListAsync();
        }
    }
}
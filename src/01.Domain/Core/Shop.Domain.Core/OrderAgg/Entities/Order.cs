using Shop.Domain.Core._Common;
using Shop.Domain.Core.Enums;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Core.OrderAgg.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }

        // Navigation
        public List<OrderItem> Items { get; set; } = [];
    }
}
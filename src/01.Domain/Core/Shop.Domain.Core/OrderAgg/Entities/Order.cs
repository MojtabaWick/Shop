using Shop.Domain.Core._Common;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Core.OrderAgg.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TotalPrice { get; set; } // مجموع قیمت سفارش

        // Navigation
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
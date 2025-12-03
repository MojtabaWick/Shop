using Shop.Domain.Core._Common;
using Shop.Domain.Core.CategoryAgg.Entities;
using Shop.Domain.Core.OrderAgg.Entities;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Core.ProductAgg.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
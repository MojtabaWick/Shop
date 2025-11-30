using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Core.UserAgg.Entities
{
    public class CartItem : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
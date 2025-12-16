using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Core.UserAgg.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
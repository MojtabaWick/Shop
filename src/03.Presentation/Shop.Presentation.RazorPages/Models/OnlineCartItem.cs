using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Presentation.RazorPages.Models
{
    public class OnlineCartItem
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
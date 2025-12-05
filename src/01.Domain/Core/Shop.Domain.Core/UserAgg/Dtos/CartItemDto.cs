using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Core.UserAgg.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public ProductSummeryDto ProductDto { get; set; }
        public int Quantity { get; set; }
    }
}
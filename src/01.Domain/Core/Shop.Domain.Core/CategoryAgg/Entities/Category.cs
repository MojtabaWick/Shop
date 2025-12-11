using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Core.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}
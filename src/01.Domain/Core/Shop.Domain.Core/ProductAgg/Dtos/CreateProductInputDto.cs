using Microsoft.AspNetCore.Http;

namespace Shop.Domain.Core.ProductAgg.Dtos
{
    public class CreateProductInputDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
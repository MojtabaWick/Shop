namespace Shop.Domain.Core.ProductAgg.Dtos
{
    public class ProductSummeryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
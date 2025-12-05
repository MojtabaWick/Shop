using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Domain.Core.ProductAgg.Contracts
{
    public interface IProductDomainService
    {
        public Task<List<ProductSummeryDto>> GetHomeProducts();

        public Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId);

        public Task<ProductDto> GetProductById(int productId);

        public Task<bool> DecreaseStock(int productId, int quantity);
    }
}
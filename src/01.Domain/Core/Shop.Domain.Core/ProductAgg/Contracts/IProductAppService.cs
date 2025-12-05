using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Core.ProductAgg.Contracts
{
    public interface IProductAppService
    {
        public Task<List<ProductSummeryDto>> GetHomeProducts();

        public Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId);

        public Task<ProductDto> GetProductById(int productId);

        public Task DecreaseStock(int productId, int quantity);
    }
}
using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Core.ProductAgg.Contracts
{
    public interface IProductRepository
    {
        public Task<List<ProductSummeryDto>> GetHomeProducts();

        public Task<List<ProductDto>> GetAllProducts();

        public Task DeleteProduct(int productId);

        public Task UpdateProductAsync(int id, ProductDto dto);

        public Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId);

        public Task<ProductDto> GetProductById(int productId);

        public Task<bool> AddProduct(Product inputProduct, CancellationToken cancellationToken);

        public Task<bool> DecreaseStock(int productId, int quantity);
    }
}
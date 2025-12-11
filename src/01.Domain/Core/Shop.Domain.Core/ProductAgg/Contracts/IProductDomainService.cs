using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Domain.Core.ProductAgg.Contracts
{
    public interface IProductDomainService
    {
        public Task<List<ProductSummeryDto>> GetHomeProducts();

        public Task<List<ProductDto>> GetAllProducts();

        public Task DeleteProduct(int productId);

        public Task UpdateProductAsync(ProductDto dto);

        public Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId);

        public Task<ProductDto> GetProductById(int productId);

        public Task<bool> DecreaseStock(int productId, int quantity);

        public Task<bool> CreateProduct(CreateProductInputDto input, CancellationToken cancellationToken);
    }
}
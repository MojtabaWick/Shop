using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Core.ProductAgg.Contracts
{
    public interface IProductAppService
    {
        public Task<List<ProductSummeryDto>> GetHomeProducts();

        public Task<List<ProductDto>> GetAllProducts();

        public Task DeleteProduct(int productId);

        public Task UpdateProduct(ProductDto dto);

        public Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId);

        public Task<ProductDto> GetProductById(int productId);

        public Task DecreaseStock(int productId, int quantity);

        public Task<Result<bool>> CreateProduct(CreateProductInputDto input, CancellationToken cancellationToken);
    }
}
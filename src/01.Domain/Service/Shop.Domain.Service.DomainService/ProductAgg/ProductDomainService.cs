using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Domain.Service.DomainService.ProductAgg
{
    public class ProductDomainService(IProductRepository productRepository) : IProductDomainService
    {
        public async Task<List<ProductSummeryDto>> GetHomeProducts()
        {
            return await productRepository.GetHomeProducts();
        }

        public async Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId)
        {
            return await productRepository.GetProductsByCategory(categoryId);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            return await productRepository.GetProductById(productId);
        }

        public async Task<bool> DecreaseStock(int productId, int quantity)
        {
            return await productRepository.DecreaseStock(productId, quantity);
        }
    }
}
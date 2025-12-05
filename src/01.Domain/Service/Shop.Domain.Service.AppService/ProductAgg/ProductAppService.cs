using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Domain.Service.AppService.ProductAgg
{
    public class ProductAppService(IProductDomainService productDomainService) : IProductAppService
    {
        public async Task<List<ProductSummeryDto>> GetHomeProducts()
        {
            return await productDomainService.GetHomeProducts();
        }

        public async Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId)
        {
            return await productDomainService.GetProductsByCategory(categoryId);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            return await productDomainService.GetProductById(productId);
        }

        public async Task DecreaseStock(int productId, int quantity)
        {
            var result = await productDomainService.DecreaseStock(productId, quantity);
            if (!result)
            {
                throw new Exception("product update stock failed.");
            }
        }
    }
}
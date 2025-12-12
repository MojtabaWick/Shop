using Microsoft.Extensions.Logging;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Domain.Service.AppService.ProductAgg
{
    public class ProductAppService(IProductDomainService productDomainService, ILogger<ProductAppService> _logger) : IProductAppService
    {
        public async Task<List<ProductSummeryDto>> GetHomeProducts()
        {
            return await productDomainService.GetHomeProducts();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return await productDomainService.GetAllProducts();
        }

        public async Task DeleteProduct(int productId)
        {
            _logger.LogWarning($"Deleting product with id : {productId}.");
            await productDomainService.DeleteProduct(productId);
        }

        public async Task UpdateProduct(ProductDto dto)
        {
            _logger.LogInformation($"Updating product with id: {dto.Id}.");
            await productDomainService.UpdateProductAsync(dto);
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

        public async Task<Result<bool>> CreateProduct(CreateProductInputDto input, CancellationToken cancellationToken)
        {
            var result = await productDomainService.CreateProduct(input, cancellationToken);

            if (result)
            {
                _logger.LogInformation("New product created.");
                return Result<bool>.Success("ایجاد محصول با موفقیت انجام شد.");
            }

            return Result<bool>.Failure("ایجاد محصول با مشکل مواجه شده است.");
        }
    }
}
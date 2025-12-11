using Shop.Domain.Core.FileAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;

namespace Shop.Domain.Service.DomainService.ProductAgg
{
    public class ProductDomainService(IProductRepository productRepository, IFileService fileService) : IProductDomainService
    {
        public async Task<List<ProductSummeryDto>> GetHomeProducts()
        {
            return await productRepository.GetHomeProducts();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }

        public async Task DeleteProduct(int productId)
        {
            await productRepository.DeleteProduct(productId);
        }

        public async Task UpdateProductAsync(ProductDto dto)
        {
            await productRepository.UpdateProductAsync(dto.Id, dto);
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

        public async Task<bool> CreateProduct(CreateProductInputDto input, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                CategoryId = input.CategoryId,
                Title = input.Title,
                ImageUrl = await fileService.Upload(input.Image, "Product", cancellationToken),
                Description = input.Description,
                Stock = input.Stock,
                Price = input.Price,
            };
            return await productRepository.AddProduct(product, cancellationToken);
        }
    }
}
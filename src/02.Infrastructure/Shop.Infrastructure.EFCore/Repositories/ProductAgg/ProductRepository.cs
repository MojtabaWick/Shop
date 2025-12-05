using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Infrastructure.EFCore.Persistence;

namespace Shop.Infrastructure.EFCore.Repositories.ProductAgg
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task<List<ProductSummeryDto>> GetHomeProducts()
        {
            return await dbContext.Products.Select(p => new ProductSummeryDto()
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
            }).ToListAsync();
        }

        public async Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId)
        {
            return await dbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new ProductSummeryDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                }).ToListAsync();
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            return await dbContext.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    ImageUrl = p.ImageUrl,
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> DecreaseStock(int productId, int quantity)
        {
            var updated = await dbContext.Products
                .Where(p => p.Id == productId)
                .Where(p => p.Stock >= quantity)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(
                        p => p.Stock,
                        p => EF.Property<int>(p, "Stock") - quantity
                    )
                );

            return updated == 1;
        }
    }
}
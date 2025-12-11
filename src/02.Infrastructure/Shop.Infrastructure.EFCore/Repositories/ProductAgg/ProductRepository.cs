using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;
using Shop.Infrastructure.EFCore.Persistence;

namespace Shop.Infrastructure.EFCore.Repositories.ProductAgg
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task<List<ProductSummeryDto>> GetHomeProducts()
        {
            return await dbContext.Products
                .AsNoTracking()
                .Select(p => new ProductSummeryDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                }).ToListAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var updatedRows = await dbContext.Products
                .Where(p => p.Id == productId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.IsDeleted, true));

            if (updatedRows == 0)
            {
                throw new Exception($"Product with Id {productId} not found.");
            }
        }

        public async Task UpdateProductAsync(int id, ProductDto dto)
        {
            var updatedRows = await dbContext.Products
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.Title, dto.Title)
                    .SetProperty(p => p.Description, dto.Description)
                    .SetProperty(p => p.ImageUrl, dto.ImageUrl)
                    .SetProperty(p => p.Price, dto.Price)
                    .SetProperty(p => p.Stock, dto.Stock));

            if (updatedRows == 0)
            {
                throw new Exception($"Product with Id {id} not found.");
            }
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            return await dbContext.Products
                .AsNoTracking()
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                }).ToListAsync();
        }

        public async Task<List<ProductSummeryDto>> GetProductsByCategory(int categoryId)
        {
            return await dbContext.Products
                .AsNoTracking()
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
            var product = await dbContext.Products
                .AsNoTracking()
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

            return product ?? throw new Exception($"Product with Id : {productId} not found.");
        }

        public async Task<bool> AddProduct(Product inputProduct, CancellationToken cancellationToken)
        {
            dbContext.Products.Add(inputProduct);

            return await dbContext.SaveChangesAsync(cancellationToken) > 0;
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
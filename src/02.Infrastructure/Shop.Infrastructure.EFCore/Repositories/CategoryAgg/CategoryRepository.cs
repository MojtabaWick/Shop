using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;
using Shop.Infrastructure.EFCore.Persistence;

namespace Shop.Infrastructure.EFCore.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext dbContext) : ICategoryRepository
    {
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await dbContext.Categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();
        }
    }
}
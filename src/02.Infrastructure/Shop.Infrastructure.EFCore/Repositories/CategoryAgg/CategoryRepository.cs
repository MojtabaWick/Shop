using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;
using Shop.Domain.Core.CategoryAgg.Entities;
using Shop.Domain.Core.ProductAgg.Entities;
using Shop.Infrastructure.EFCore.Persistence;

namespace Shop.Infrastructure.EFCore.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext dbContext) : ICategoryRepository
    {
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToListAsync();
        }

        public async Task DeleteAsync(int categoryId)
        {
            var updatedRows = await dbContext.Categories
                .Where(c => c.Id == categoryId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.IsDeleted, true));

            if (updatedRows == 0)
            {
                throw new Exception($"Category with Id {categoryId} not found.");
            }
        }

        public async Task<bool> CreateAsync(Category category, CancellationToken cancellationToken)
        {
            dbContext.Categories.Add(category);

            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<CategoryDto> GetByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            var category = await dbContext.Categories
                 .AsNoTracking()
                 .Where(c => c.Id == categoryId)
                 .Select(c => new CategoryDto()
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Description = c.Description,
                 })
                 .FirstOrDefaultAsync();

            if (category is null)
            {
                throw new Exception($"Category with Id : {categoryId} not found.");
            }
            else
            {
                return category;
            }
        }

        public async Task UpdateAsync(CategoryDto dto, CancellationToken cancellationToken)
        {
            await dbContext.Categories
               .Where(c => c.Id == dto.Id)
               .ExecuteUpdateAsync(setter => setter
                   .SetProperty(c => c.Name, dto.Name)
                   .SetProperty(c => c.Description, dto.Description));
        }
    }
}
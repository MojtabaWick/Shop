using Shop.Domain.Core._Common;
using Shop.Domain.Core.CategoryAgg.Dtos;
using Shop.Domain.Core.CategoryAgg.Entities;

namespace Shop.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryDto>> GetAllCategories();

        public Task DeleteAsync(int categoryId);

        public Task<bool> CreateAsync(Category category, CancellationToken cancellationToken);

        public Task<CategoryDto> GetByIdAsync(int categoryId, CancellationToken cancellationToken);

        public Task UpdateAsync(CategoryDto dto, CancellationToken cancellationToken);
    }
}
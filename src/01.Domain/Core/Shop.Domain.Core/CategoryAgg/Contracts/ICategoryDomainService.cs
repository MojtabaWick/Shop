using Shop.Domain.Core._Common;
using Shop.Domain.Core.CategoryAgg.Dtos;

namespace Shop.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryDomainService
    {
        public Task<List<CategoryDto>> GetAllCategories();

        public Task DeleteAsync(int categoryId);

        public Task<bool> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken);

        public Task<CategoryDto> GetByIdAsync(int categoryId, CancellationToken cancellationToken);

        public Task UpdateAsync(CategoryDto dto, CancellationToken cancellationToken);
    }
}
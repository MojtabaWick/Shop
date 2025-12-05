using Shop.Domain.Core.CategoryAgg.Dtos;

namespace Shop.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryDto>> GetAllCategories();
    }
}
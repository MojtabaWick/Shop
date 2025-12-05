using Shop.Domain.Core.CategoryAgg.Dtos;

namespace Shop.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryAppService
    {
        public Task<List<CategoryDto>> GetAllCategories();
    }
}
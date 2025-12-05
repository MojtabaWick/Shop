using Shop.Domain.Core.CategoryAgg.Dtos;

namespace Shop.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryDomainService
    {
        public Task<List<CategoryDto>> GetAllCategories();
    }
}
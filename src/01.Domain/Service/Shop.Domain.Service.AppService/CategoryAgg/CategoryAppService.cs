using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;

namespace Shop.Domain.Service.AppService.CategoryAgg
{
    public class CategoryAppService(ICategoryDomainService categoryDomainService) : ICategoryAppService
    {
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await categoryDomainService.GetAllCategories();
        }
    }
}
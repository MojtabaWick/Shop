using Shop.Domain.Core._Common;
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

        public async Task DeleteAsync(int categoryId)
        {
            await categoryDomainService.DeleteAsync(categoryId);
        }

        public async Task<Result<bool>> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await categoryDomainService.CreateAsync(dto, cancellationToken);

            if (result)
            {
                return Result<bool>.Success("ایجاد دسته بندی با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure("ایجاد دسته بندی با مشکل مواجه شده است.");
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await categoryDomainService.GetByIdAsync(categoryId, cancellationToken);
        }

        public async Task UpdateAsync(CategoryDto dto, CancellationToken cancellationToken)
        {
            await categoryDomainService.UpdateAsync(dto, cancellationToken);
        }
    }
}
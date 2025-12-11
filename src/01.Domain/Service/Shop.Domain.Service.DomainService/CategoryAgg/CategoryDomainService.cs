using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Core.CategoryAgg.Entities;

namespace Shop.Domain.Service.DomainService.CategoryAgg
{
    public class CategoryDomainService(ICategoryRepository categoryRepository) : ICategoryDomainService
    {
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await categoryRepository.GetAllCategories();
        }

        public async Task DeleteAsync(int categoryId)
        {
            await categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<bool> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
        {
            var newCategory = new Category()
            {
                Name = dto.Name,
                Description = dto.Description,
            };
            return await categoryRepository.CreateAsync(newCategory, cancellationToken);
        }

        public async Task<CategoryDto> GetByIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await categoryRepository.GetByIdAsync(categoryId, cancellationToken);
        }

        public async Task UpdateAsync(CategoryDto dto, CancellationToken cancellationToken)
        {
            await categoryRepository.UpdateAsync(dto, cancellationToken);
        }
    }
}
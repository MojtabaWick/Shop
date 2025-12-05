using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Service.DomainService.CategoryAgg
{
    public class CategoryDomainService(ICategoryRepository categoryRepository) : ICategoryDomainService
    {
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await categoryRepository.GetAllCategories();
        }
    }
}
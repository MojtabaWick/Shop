using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly ICategoryAppService _categoryService;

        public IndexModel(ICategoryAppService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetAllCategories();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
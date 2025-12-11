using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Products
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateProductInputDto Product { get; set; }

        public List<CategoryDto> Categories { get; set; }

        private readonly IProductAppService _productService;
        private readonly ICategoryAppService _categoryService;

        public CreateModel(IProductAppService productService, ICategoryAppService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetAllCategories();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = await _categoryService.GetAllCategories();
                return Page();
            }

            await _productService.CreateProduct(Product, default);

            return RedirectToPage("/Products/Index");
        }
    }
}
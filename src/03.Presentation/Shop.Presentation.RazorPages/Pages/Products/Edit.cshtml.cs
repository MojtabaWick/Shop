using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public ProductDto Product { get; set; }

        private readonly IProductAppService _productAppService;

        public EditModel(IProductAppService prosucAppService)
        {
            _productAppService = prosucAppService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productAppService.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productAppService.UpdateProduct(Product);

            return RedirectToPage("/Products/Index");
        }
    }
}
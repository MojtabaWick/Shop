using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<ProductDto> Products { get; set; }

        private readonly IProductAppService _productService;

        public IndexModel(IProductAppService productService)
        {
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllProducts();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToPage();
        }
    }
}
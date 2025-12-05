using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Presentation.RazorPages.DataBase;

namespace Shop.Presentation.RazorPages.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly IUserAppService _userAppService;

        public ProductDto Product { get; set; }

        public ProductModel(IProductAppService productAppService, IUserAppService userAppService)
        {
            _productAppService = productAppService;
            _userAppService = userAppService;
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

        public IActionResult OnPostAddToCart(int id)
        {
            _userAppService.AddToCart(InMemoryDataBase.OnlineUser.Id, id, 1);
            return RedirectToPage(new { id });
        }
    }
}
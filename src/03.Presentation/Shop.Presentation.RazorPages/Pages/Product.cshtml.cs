using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Entities;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Presentation.RazorPages.DataBase;
using Shop.Presentation.RazorPages.Extentions;
using Shop.Presentation.RazorPages.Services.OnlineCartItem;

namespace Shop.Presentation.RazorPages.Pages
{
    public class ProductModel : BasePageModel
    {
        private readonly IProductAppService _productAppService;
        private readonly IUserAppService _userAppService;
        private readonly IOnlineCartItemService _onlineCartItemService;

        public ProductDto Product { get; set; }

        public ProductModel(IProductAppService productAppService,
            IUserAppService userAppService,
            IOnlineCartItemService onlineCartItemService)
        {
            _productAppService = productAppService;
            _userAppService = userAppService;
            _onlineCartItemService = onlineCartItemService;
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

        public IActionResult OnPostAddToCart(int productId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                _onlineCartItemService.AddOnlineCartItem(productId);
                return RedirectToPage(new { productId });
            }
            else
            {
                _userAppService.AddToCart((int)GetUserId()!, productId, 1);
                return RedirectToPage(new { productId });
            }
        }
    }
}
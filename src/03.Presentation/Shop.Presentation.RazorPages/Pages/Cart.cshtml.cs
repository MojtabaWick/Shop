using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Presentation.RazorPages.DataBase;
using Shop.Presentation.RazorPages.Extentions;

namespace Shop.Presentation.RazorPages.Pages
{
    [Authorize]
    public class CartModel : BasePageModel
    {
        private readonly IUserAppService _userAppService;
        private readonly IOrderAppService _orderService;
        private readonly ILogger<CartModel> _logger;

        public CartModel(IUserAppService userAppService, IOrderAppService orderService, ILogger<CartModel> logger)
        {
            _userAppService = userAppService;
            _orderService = orderService;
            _logger = logger;
        }

        public List<CartItemDto> CartItems { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int userId = (int)GetUserId();

            CartItems = await _userAppService.GetCartItemsByUserId(userId);

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync([FromForm] List<CartItemUpdateDto> updatedItems)
        {
            if (updatedItems == null)
                return BadRequest();

            await _userAppService.UpdateCartItems(updatedItems);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetDelete(int Id)
        {
            await _userAppService.DeleteCartItem(Id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCreateOrderAsync()
        {
            int orderId = await _orderService.CreateOrderFromCart((int)GetUserId()!);
            if (orderId == 0)
            {
                return Page();
            }
            return RedirectToPage("/Order", new { orderId });
        }
    }
}
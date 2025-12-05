using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Presentation.RazorPages.DataBase;

namespace Shop.Presentation.RazorPages.Pages
{
    public class CartModel : PageModel
    {
        private readonly IUserAppService _userAppService;
        private readonly IOrderAppService _orderService;

        public CartModel(IUserAppService userAppService, IOrderAppService orderService)
        {
            _userAppService = userAppService;
            _orderService = orderService;
        }

        public List<CartItemDto> CartItems { get; set; }

        public async Task OnGetAsync()
        {
            int userId = InMemoryDataBase.OnlineUser.Id;
            CartItems = await _userAppService.GetCartItemsByUserId(userId);
        }

        public async Task<IActionResult> OnPostUpdateAsync(List<CartItemUpdateDto> updatedItems)
        {
            await _userAppService.UpdateCartItems(updatedItems);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCreateOrderAsync()
        {
            int userId = InMemoryDataBase.OnlineUser.Id;

            int orderId = await _orderService.CreateOrderFromCart(userId);
            if (orderId == 0)
            {
                // هندل کردن خطا، مثلاً ModelState.AddModelError
                return Page();
            }
            return RedirectToPage("/Order", new { orderId });
        }
    }
}
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
            if (InMemoryDataBase.OnlineUser is null)
            {
                return RedirectToPage("/Account/Login");
            }

            int userId = InMemoryDataBase.OnlineUser.Id;
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
            if (InMemoryDataBase.OnlineUser is null)
            {
                return RedirectToPage("/Account/Login");
            }
            else
            {
                int orderId = await _orderService.CreateOrderFromCart(InMemoryDataBase.OnlineUser.Id);
                if (orderId == 0)
                {
                    return Page();
                }
                return RedirectToPage("/Order", new { orderId });
            }
        }
    }
}
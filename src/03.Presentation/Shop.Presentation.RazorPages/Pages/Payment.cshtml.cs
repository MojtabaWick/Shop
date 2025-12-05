using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Entities;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Presentation.RazorPages.DataBase;

namespace Shop.Presentation.RazorPages.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly IOrderAppService _orderService;
        private readonly IUserAppService _userAppService;

        public PaymentModel(IOrderAppService orderService, IUserAppService userAppService)
        {
            _orderService = orderService;
            _userAppService = userAppService;
        }

        public Order Order { get; set; }
        public decimal WalletBalance { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            int userId = InMemoryDataBase.OnlineUser.Id;
            Order = await _orderService.GetOrderById(orderId);
            if (Order == null || Order.UserId != userId)
            {
                return NotFound();
            }

            WalletBalance = await _userAppService.GetUserWalletBalance(userId);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int orderId)
        {
            int userId = InMemoryDataBase.OnlineUser.Id;
            var result = await _orderService.PayOrder(orderId, userId);
            if (result.IsSuccess)
            {
                return RedirectToPage("/OrderSuccess", new { orderId });
            }
            else
            {
                // دوباره سفارش را لود می‌کنیم تا در صفحه نمایش داده شود
                Order = await _orderService.GetOrderById(orderId);
                if (Order == null || Order.UserId != userId)
                {
                    return NotFound();
                }
                WalletBalance = await _userAppService.GetUserWalletBalance(userId);
                Message = result.Message!;
                return Page();
            }
        }
    }
}
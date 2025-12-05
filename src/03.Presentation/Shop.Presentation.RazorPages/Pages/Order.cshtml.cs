using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Entities;

namespace Shop.Presentation.RazorPages.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderAppService _orderService;

        public OrderModel(IOrderAppService orderService)
        {
            _orderService = orderService;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            Order = await _orderService.GetOrderById(orderId);
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
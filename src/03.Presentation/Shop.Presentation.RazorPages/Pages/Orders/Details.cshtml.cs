using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Orders
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderAppService _orderService;

        public DetailsModel(IOrderAppService orderService)
        {
            _orderService = orderService;
        }

        public OrderDetailDto Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Order = await _orderService.GetOrderWithDetailById(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.OrderAgg.Contracts;
using Shop.Domain.Core.OrderAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IOrderAppService _orderService;

        public IndexModel(IOrderAppService orderService)
        {
            _orderService = orderService;
        }

        public List<OrderSummeryDto> Orders { get; set; } = [];

        public async Task OnGetAsync()
        {
            Orders = await _orderService.GetAllOrdersAsync();
        }
    }
}
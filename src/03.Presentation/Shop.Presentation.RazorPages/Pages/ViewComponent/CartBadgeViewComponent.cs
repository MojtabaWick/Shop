using global::Shop.Domain.Core.UserAgg.Contracts;
using global::Shop.Presentation.RazorPages.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Shop.Presentation.RazorPages.Pages.ViewComponent;

[ViewComponent(Name = "CartBadge")]
public class CartBadgeViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IUserAppService _userAppService;

    public CartBadgeViewComponent(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        int cartCount;

        if (!User.Identity.IsAuthenticated)
        {
            cartCount = InMemoryDataBase.OnlineCartItems.Count;
        }
        else
        {
            string? userIdStr = HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;

            if (!string.IsNullOrEmpty(userIdStr) && int.TryParse(userIdStr, out int userId))
            {
                cartCount = await _userAppService.UserCartItemsCount(userId);
            }

            cartCount = 0;
        }

        return View(cartCount); // برمی‌گردونه به ویو (که فقط عدد رو نمایش می‌ده)
    }
}
using global::Shop.Domain.Core.UserAgg.Contracts;
using global::Shop.Presentation.RazorPages.DataBase;
using Microsoft.AspNetCore.Mvc;

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

        if (InMemoryDataBase.OnlineUser is null)
        {
            cartCount = InMemoryDataBase.OnlineCartItems.Count;
        }
        else
        {
            cartCount = await _userAppService.UserCartItemsCount(InMemoryDataBase.OnlineUser.Id);
        }

        return View(cartCount); // برمی‌گردونه به ویو (که فقط عدد رو نمایش می‌ده)
    }
}
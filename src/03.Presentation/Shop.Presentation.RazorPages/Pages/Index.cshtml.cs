using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Presentation.RazorPages.DataBase;

namespace Shop.Presentation.RazorPages.Pages;

public class IndexModel(IProductAppService productAppService, IUserAppService userAppService) : PageModel
{
    public List<ProductSummeryDto> Products { get; set; }
    public int CartCount { get; set; }

    public async Task OnGetAsync()
    {
        Products = await productAppService.GetHomeProducts();
        CartCount = 0;
        ViewData["CartCount"] = CartCount;
    }

    public IActionResult OnPostAddToCart(int id)
    {
        // TODO: اینجا بعداً آیتم رو به سبد خرید اضافه می‌کنی
        userAppService.AddToCart(InMemoryDataBase.OnlineUser.Id, id, 1);
        return RedirectToPage();
    }
}
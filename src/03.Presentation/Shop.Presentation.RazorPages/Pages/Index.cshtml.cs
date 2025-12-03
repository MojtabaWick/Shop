using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop.Presentation.RazorPages.Pages;

public class IndexModel : PageModel
{
    public List<ProductDto> Products { get; set; }
    public int CartCount { get; set; }

    public void OnGet()
    {
        Products = new()
        {
            new ProductDto { Id = 1, Name = "کیف ورزشی", Description = "کیف محکم و با کیفیت", Price = 350000, ImageUrl = "https://via.placeholder.com/400x250" },
            new ProductDto { Id = 2, Name = "کفش مردانه", Description = "مناسب پیاده‌روی", Price = 720000, ImageUrl = "https://via.placeholder.com/400x250" },
            new ProductDto { Id = 3, Name = "هدفون بلوتوث", Description = "صدای با کیفیت بالا", Price = 450000, ImageUrl = "https://via.placeholder.com/400x250" },
        };
        CartCount = 1;
        ViewData["CartCount"] = CartCount;
    }

    public IActionResult OnPostAddToCart(int id)
    {
        // TODO: اینجا بعداً آیتم رو به سبد خرید اضافه می‌کنی
        return RedirectToPage();
    }
}

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
}
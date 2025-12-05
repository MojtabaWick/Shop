using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.CategoryAgg.Contracts;
using Shop.Domain.Core.CategoryAgg.Dtos;
using Shop.Domain.Core.ProductAgg.Contracts;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Presentation.RazorPages.DataBase;

namespace Shop.Presentation.RazorPages.Pages;

public class IndexModel : PageModel
{
    private readonly IProductAppService _productAppService;
    private readonly IUserAppService _userAppService;
    private readonly ICategoryAppService _categoryAppService;

    public List<ProductSummeryDto> Products { get; set; }
    public List<CategoryDto> Categories { get; set; }
    public int CartCount { get; set; }
    public int? SelectedCategoryId { get; set; }

    public IndexModel(IProductAppService productAppService,
        IUserAppService userAppService,
        ICategoryAppService categoryAppService)
    {
        _productAppService = productAppService;
        _userAppService = userAppService;
        _categoryAppService = categoryAppService;
    }

    public async Task OnGetAsync(int? categoryId = null)
    {
        Categories = await _categoryAppService.GetAllCategories();
        ViewData["Categories"] = Categories;

        if (categoryId.HasValue)
        {
            Products = await _productAppService.GetProductsByCategory(categoryId.Value);
            SelectedCategoryId = categoryId.Value;
        }
        else
        {
            Products = await _productAppService.GetHomeProducts();
        }

        CartCount = 0;
        ViewData["CartCount"] = CartCount;
    }

    public IActionResult OnPostAddToCart(int id)
    {
        _userAppService.AddToCart(InMemoryDataBase.OnlineUser.Id, id, 1);
        return RedirectToPage();
    }
}
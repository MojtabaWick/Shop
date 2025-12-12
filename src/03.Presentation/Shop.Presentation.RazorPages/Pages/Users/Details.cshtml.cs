using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IUserAppService _userService;

        public DetailsModel(IUserAppService userService)
        {
            _userService = userService;
        }

        public UserWithDetailDto User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _userService.GetUserByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
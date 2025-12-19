using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Presentation.RazorPages.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IUserAppService _userAppService;

        public LogoutModel(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _userAppService.Logout();

            return RedirectToPage("/Account/Login");
        }
    }
}
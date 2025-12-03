using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Presentation.RazorPages.DataBase;
using Shop.Presentation.RazorPages.Models;

namespace Shop.Presentation.RazorPages.Pages
{
    public class LoginModel(IUserAppService userAppService) : PageModel
    {
        public string ResultMessage { get; set; }

        [BindProperty]
        public UserLoginInput User { get; set; } = new UserLoginInput();

        public async Task OnGet(string message)
        {
            ResultMessage = message;
        }

        public async Task<IActionResult> OnPost()
        {
            var loginResult = await userAppService.Login(User);

            if (loginResult.IsSuccess)
            {
                InMemoryDataBase.OnlineUser = new OnlineUser
                {
                    Id = loginResult.Data.Id,
                    FullName = loginResult.Data.FullName,
                };

                return RedirectToPage("/Admin/Posts/Index");
            }

            return RedirectToPage("/Account/Login", new { message = loginResult.Message });
        }
    }
}
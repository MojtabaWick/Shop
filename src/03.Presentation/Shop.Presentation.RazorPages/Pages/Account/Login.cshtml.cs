using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Presentation.RazorPages.DataBase;
using Shop.Presentation.RazorPages.Models;
using Shop.Presentation.RazorPages.Services.OnlineCartItem;

namespace Shop.Presentation.RazorPages.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserAppService _userAppService;
        private readonly IOnlineCartItemService _onlineCartItemService;

        public LoginModel(IUserAppService userAppService, IOnlineCartItemService onlineCartItemService)
        {
            _userAppService = userAppService;
            _onlineCartItemService = onlineCartItemService;
        }

        public string? ResultMessage { get; set; }

        [BindProperty]
        public UserLoginInput User { get; set; } = new UserLoginInput();

        public void OnGet(string? message)
        {
            ResultMessage = message;
        }

        public async Task<IActionResult> OnPost()
        {
            var loginResult = await _userAppService.Login(User);

            if (loginResult.IsSuccess)
            {
                InMemoryDataBase.OnlineUser = new OnlineUser
                {
                    Id = loginResult.Data!.Id,
                    FullName = loginResult.Data.FullName,
                };

                _onlineCartItemService.AddOnlineCartItemsToDataBase(InMemoryDataBase.OnlineUser.Id);

                return RedirectToPage("/Index");
            }

            return RedirectToPage("/Account/Login", new { message = loginResult.Message });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Presentation.RazorPages.DataBase;
using Shop.Presentation.RazorPages.Extentions;
using Shop.Presentation.RazorPages.Models;
using Shop.Presentation.RazorPages.Services.OnlineCartItem;

namespace Shop.Presentation.RazorPages.Pages.Account
{
    public class LoginModel : BasePageModel
    {
        private readonly IUserAppService _userAppService;
        private readonly IOnlineCartItemService _onlineCartItemService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(IUserAppService userAppService,
            IOnlineCartItemService onlineCartItemService,
            ILogger<LoginModel> logger)
        {
            _userAppService = userAppService;
            _onlineCartItemService = onlineCartItemService;
            _logger = logger;
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
                _onlineCartItemService.AddOnlineCartItemsToDataBase((int)GetUserId()!);

                return RedirectToPage(GetUserId() == 1 ? "/Admin/Index" : "/Index");
            }

            return RedirectToPage("/Account/Login", new { message = loginResult.Message });
        }
    }
}
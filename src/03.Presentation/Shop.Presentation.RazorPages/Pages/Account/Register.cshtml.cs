using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Presentation.RazorPages.Pages.Account
{
    public class RegisterModel(IUserAppService userAppService) : PageModel
    {
        [BindProperty]
        public UserRegisterInput Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await userAppService.Register(Input);

            if (result.IsSuccess)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, result.Message);

            return Page();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Service.AppService.UserAgg
{
    public class UserAppService(IUserDomainService userDomainService, ILogger<UserAppService> _logger, UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager) : IUserAppService
    {
        public async Task<Result<bool>> Login(UserLoginInput input)
        {
            var result = await signInManager.PasswordSignInAsync(input.PhoneNumber, input.Password, false, false);
            if (result.Succeeded)
            {
                //_logger.LogInformation($"User with id: {result.Id} logged in.");
                return Result<bool>.Success("ورود با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure("نام کاربری یا رمز عبور اشتباه است.");
            }

            //var result = await userDomainService.Login(input);
            //if (result is null)
            //{
            //    return Result<LoginOutputDto>.Failure("نام کاربری یا رمز عبور اشتباه است.");
            //}
            //else
            //{
            //    _logger.LogInformation($"User with id: {result.Id} logged in.");
            //    return Result<LoginOutputDto>.Success("ورود با موفقیت انجام شد.", result);
            //}
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Result<bool>> Register(UserRegisterInput input)
        {
            var newUser = new ApplicationUser
            {
                UserName = input.PhoneNumber,
                PhoneNumber = input.PhoneNumber,
                Email = input.Email,
                FullName = input.FirstName + " " + input.LastName,
            };

            var result = await userManager.CreateAsync(newUser, input.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, "User");

                return Result<bool>.Success("ثبت نام با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure("خطا در ثبت نام.");
            }
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(user);
            }
            return result;
        }

        public async Task<UserWithDetailDto> GetUserByIdAsync(int id)
        {
            return await userDomainService.GetUserByIdAsync(id);
        }

        public async Task<List<UserSummeryDto>> GetAllUsersAsync()
        {
            return await userDomainService.GetAllUsersAsync();
        }

        public async Task<Result<bool>> AddToCart(int userId, int productId, int quantity)
        {
            var result = await userDomainService.AddToCart(userId, productId, quantity);
            if (!result)
            {
                _logger.LogError("error in adding a new cart item.");
                return Result<bool>.Failure("خطا در افزودن به سبد خرید.");
            }
            else
            {
                _logger.LogInformation("New cart item added successfully.");
                return Result<bool>.Success("محصول با موفقیت به سبد خرید اضافه شد.");
            }
        }

        public async Task AddListCartItems(List<CartItemInputDto> input)
        {
            await userDomainService.AddListCartItems(input);
        }

        public async Task<List<CartItemDto>> GetCartItemsByUserId(int userId)
        {
            return await userDomainService.GetCartItemsByUserId(userId);
        }

        public async Task UpdateCartItems(List<CartItemUpdateDto> updatedItems)
        {
            _logger.LogInformation($"Updating cart items.");
            await userDomainService.UpdateCartItems(updatedItems);
        }

        public async Task<int> UserCartItemsCount(int userId)
        {
            return await userDomainService.UsrCartItemsCount(userId);
        }

        public async Task<decimal> GetUserWalletBalance(int userId)
        {
            return await userDomainService.GetUserWalletBalance(userId);
        }

        public async Task<bool> DecreaseUserWalletBalance(int userId, decimal amount)
        {
            return await userDomainService.DecreaseUserWalletBalance(userId, amount);
        }

        public async Task<bool> IncreaseUserWalletBalance(int userId, decimal amount)
        {
            return await userDomainService.IncreaseUserWalletBalance(userId, amount);
        }

        public async Task DeleteCartItem(int CartId)
        {
            _logger.LogWarning($"Deleting Cart items from cart with id {CartId}.");

            await userDomainService.DeleteCartItem(CartId);
        }
    }
}
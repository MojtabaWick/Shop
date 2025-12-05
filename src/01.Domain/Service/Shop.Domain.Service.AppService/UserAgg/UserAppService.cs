using Shop.Domain.Core._Common;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Domain.Service.AppService.UserAgg
{
    public class UserAppService(IUserDomainService userDomainService) : IUserAppService
    {
        public async Task<Result<LoginOutputDto>> Login(UserLoginInput input)
        {
            var result = await userDomainService.Login(input);
            if (result is null)
            {
                return Result<LoginOutputDto>.Failure("نام کاربری یا رمز عبور اشتباه است.");
            }
            else
            {
                return Result<LoginOutputDto>.Success("ورود با موفقیت انجام شد.", result);
            }
        }

        public async Task<Result<bool>> AddToCart(int userId, int productId, int quantity)
        {
            var result = await userDomainService.AddToCart(userId, productId, quantity);
            if (!result)
            {
                return Result<bool>.Failure("خطا در افزودن به سبد خرید.");
            }
            else
            {
                return Result<bool>.Success("محصول با موفقیت به سبد خرید اضافه شد.");
            }
        }

        public async Task<List<CartItemDto>> GetCartItemsByUserId(int userId)
        {
            return await userDomainService.GetCartItemsByUserId(userId);
        }

        public async Task UpdateCartItems(List<CartItemUpdateDto> updatedItems)
        {
            await userDomainService.UpdateCartItems(updatedItems);
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
    }
}
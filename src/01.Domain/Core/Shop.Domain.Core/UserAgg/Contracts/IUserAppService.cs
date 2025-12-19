using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Domain.Core.UserAgg.Contracts
{
    public interface IUserAppService
    {
        public Task<Result<bool>> Login(UserLoginInput input);

        public Task<Result<bool>> Register(UserRegisterInput input);

        public Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword);

        public Task<UserWithDetailDto> GetUserByIdAsync(int id);

        public Task<List<UserSummeryDto>> GetAllUsersAsync();

        public Task<Result<bool>> AddToCart(int userId, int productId, int quantity);

        public Task AddListCartItems(List<CartItemInputDto> input);

        public Task<List<CartItemDto>> GetCartItemsByUserId(int userId);

        public Task UpdateCartItems(List<CartItemUpdateDto> updatedItems);

        public Task<int> UserCartItemsCount(int userId);

        public Task<decimal> GetUserWalletBalance(int userId);

        public Task<bool> DecreaseUserWalletBalance(int userId, decimal amount);

        public Task<bool> IncreaseUserWalletBalance(int userId, decimal amount);

        public Task DeleteCartItem(int CartId);
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Domain.Core.UserAgg.Contracts
{
    public interface IUserAppService
    {
        public Task<Result<LoginOutputDto>> Login(UserLoginInput input);

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
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Core.UserAgg.Contracts
{
    public interface IUserRepository
    {
        public Task<LoginOutputDto?> Login(UserLoginInput input);

        public Task AddListCartItems(List<CartItem> input);

        public Task<int> UsrCartItemsCount(int userId);

        public Task<bool> AddToCart(CartItem cartItem);

        public Task<List<CartItemDto>> GetCartItemsByUserId(int userId);

        public Task UpdateCartItems(List<CartItemUpdateDto> updatedItems);

        public Task<decimal> GetUserWalletBalance(int userId);

        public Task<bool> DecreaseUserWalletBalance(int userId, decimal amount);

        public Task<bool> IncreaseUserWalletBalance(int userId, decimal amount);

        public Task DeleteCartItem(int CartId);
    }
}
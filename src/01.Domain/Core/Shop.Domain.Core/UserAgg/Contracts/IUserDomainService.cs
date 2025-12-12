using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Domain.Core.UserAgg.Contracts
{
    public interface IUserDomainService
    {
        public Task<LoginOutputDto?> Login(UserLoginInput input);

        public Task<UserWithDetailDto> GetUserByIdAsync(int id);

        public Task<List<UserSummeryDto>> GetAllUsersAsync();

        public Task<bool> AddToCart(int userId, int productId, int quantity);

        public Task AddListCartItems(List<CartItemInputDto> input);

        public Task<int> UsrCartItemsCount(int userId);

        public Task<List<CartItemDto>> GetCartItemsByUserId(int userId);

        public Task UpdateCartItems(List<CartItemUpdateDto> updatedItems);

        public Task<decimal> GetUserWalletBalance(int userId);

        public Task<bool> DecreaseUserWalletBalance(int userId, decimal amount);

        public Task<bool> IncreaseUserWalletBalance(int userId, decimal amount);

        public Task DeleteCartItem(int CartId);
    }
}
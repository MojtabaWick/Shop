using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Service.DomainService.UserAgg
{
    public class UserDomainService(IUserRepository userRepository) : IUserDomainService
    {
        public async Task<LoginOutputDto?> Login(UserLoginInput input)
        {
            return await userRepository.Login(input);
        }

        public async Task<UserWithDetailDto> GetUserByIdAsync(int id)
        {
            return await userRepository.GetUserByIdAsync(id);
        }

        public async Task<List<UserSummeryDto>> GetAllUsersAsync()
        {
            return await userRepository.GetAllUsersAsync();
        }

        public async Task<bool> AddToCart(int userId, int productId, int quantity)
        {
            var cartItem = new CartItem()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            };

            return await userRepository.AddToCart(cartItem);
        }

        public async Task AddListCartItems(List<CartItemInputDto> input)
        {
            var newListCartItem = new List<CartItem>();

            foreach (var item in input)
            {
                var newCartItem = new CartItem()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UserId = item.UserId,
                };
                newListCartItem.Add(newCartItem);
            }

            await userRepository.AddListCartItems(newListCartItem);
        }

        public async Task<int> UsrCartItemsCount(int userId)
        {
            return await userRepository.UsrCartItemsCount(userId);
        }

        public async Task<List<CartItemDto>> GetCartItemsByUserId(int userId)
        {
            return await userRepository.GetCartItemsByUserId(userId);
        }

        public async Task UpdateCartItems(List<CartItemUpdateDto> updatedItems)
        {
            await userRepository.UpdateCartItems(updatedItems);
        }

        public async Task<decimal> GetUserWalletBalance(int userId)
        {
            return await userRepository.GetUserWalletBalance(userId);
        }

        public async Task<bool> DecreaseUserWalletBalance(int userId, decimal amount)
        {
            return await userRepository.DecreaseUserWalletBalance(userId, amount);
        }

        public async Task<bool> IncreaseUserWalletBalance(int userId, decimal amount)
        {
            return await userRepository.IncreaseUserWalletBalance(userId, amount);
        }

        public async Task DeleteCartItem(int CartId)
        {
            await userRepository.DeleteCartItem(CartId);
        }
    }
}
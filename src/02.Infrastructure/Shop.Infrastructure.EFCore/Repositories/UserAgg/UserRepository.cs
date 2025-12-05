using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.ProductAgg.Dtos;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
using Shop.Domain.Core.UserAgg.Entities;
using Shop.Infrastructure.EFCore.Persistence;

namespace Shop.Infrastructure.EFCore.Repositories.UserAgg
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<LoginOutputDto?> Login(UserLoginInput input)
        {
            return await dbContext.Users
                .Where(u => u.PhoneNumber == input.PhoneNumber && u.Password == input.Password)
                .Select(u => new LoginOutputDto()
                {
                    Id = u.Id,
                    FullName = u.FullName,
                }).FirstOrDefaultAsync();
        }

        public async Task AddListCartItems(List<CartItem> input)
        {
            await dbContext.CartItems.AddRangeAsync(input);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> UsrCartItemsCount(int userId)
        {
            return await dbContext.CartItems
                .Where(c => c.UserId == userId)
                .CountAsync();
        }

        public async Task<bool> AddToCart(CartItem cartItem)
        {
            await dbContext.CartItems.AddAsync(cartItem);

            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<CartItemDto>> GetCartItemsByUserId(int userId)
        {
            return await dbContext.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Product)
                .Select(ci => new CartItemDto
                {
                    Id = ci.Id,
                    Quantity = ci.Quantity,
                    ProductDto = new ProductSummeryDto
                    {
                        Id = ci.Product.Id,
                        Title = ci.Product.Title,
                        ImageUrl = ci.Product.ImageUrl,
                        Price = ci.Product.Price
                    }
                })
                .ToListAsync();
        }

        public async Task UpdateCartItems(List<CartItemUpdateDto> updatedItems)
        {
            foreach (var updatedItem in updatedItems)
            {
                var cartItem = await dbContext.CartItems.FindAsync(updatedItem.Id);
                if (cartItem != null)
                {
                    cartItem.Quantity = updatedItem.Quantity;
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<decimal> GetUserWalletBalance(int userId)
        {
            return await dbContext.Users.Where(u => u.Id == userId).Select(u => u.WalletBalance).FirstOrDefaultAsync();
        }

        public async Task<bool> DecreaseUserWalletBalance(int userId, decimal amount)
        {
            var updated = await dbContext.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(
                        u => u.WalletBalance,
                        u => u.WalletBalance - amount
                    )
                );

            return updated == 1;
        }

        public async Task<bool> IncreaseUserWalletBalance(int userId, decimal amount)
        {
            var updated = await dbContext.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(
                        u => u.WalletBalance,
                        u => u.WalletBalance + amount
                    )
                );

            return updated == 1;
        }

        public async Task DeleteCartItem(int CartId)
        {
            await dbContext.CartItems.Where(c => c.Id == CartId).ExecuteDeleteAsync();
        }
    }
}
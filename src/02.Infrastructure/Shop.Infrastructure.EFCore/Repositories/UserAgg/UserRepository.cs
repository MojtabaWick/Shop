using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;
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
    }
}
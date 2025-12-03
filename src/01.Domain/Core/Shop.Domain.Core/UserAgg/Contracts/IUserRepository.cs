using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Domain.Core.UserAgg.Contracts
{
    public interface IUserRepository
    {
        public Task<LoginOutputDto?> Login(UserLoginInput input);
    }
}
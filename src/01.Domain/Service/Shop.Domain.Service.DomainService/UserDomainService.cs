using Shop.Domain.Core.UserAgg.Contracts;
using Shop.Domain.Core.UserAgg.Dtos;

namespace Shop.Domain.Service.DomainService
{
    public class UserDomainService(IUserRepository userRepository) : IUserDomainService
    {
        public async Task<LoginOutputDto?> Login(UserLoginInput input)
        {
            return await userRepository.Login(input);
        }
    }
}
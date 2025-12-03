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
    }
}
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
    }
}
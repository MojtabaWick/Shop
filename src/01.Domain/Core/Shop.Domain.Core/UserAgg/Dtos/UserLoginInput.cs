using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Core.UserAgg.Dtos
{
    public class UserLoginInput
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
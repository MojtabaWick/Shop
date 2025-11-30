using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Core.Enums
{
    public enum OrderStatus
    {
        Pending,    // تازه ایجاد شده
        Paid,       // پرداخت شده
        Shipped,    // ارسال شده
        Completed,  // تکمیل شده
        Cancelled   // لغو شده
    }
}
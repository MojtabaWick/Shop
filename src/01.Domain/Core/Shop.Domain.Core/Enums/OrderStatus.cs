using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Core.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "تازه ایجاد شده")]
        Pending,

        [Display(Name = "پرداخت شده")]
        Paid,

        [Display(Name = "ارسال شده")]
        Shipped,

        [Display(Name = "تکمیل شده")]
        Completed,

        [Display(Name = "لغو شده")]
        Cancelled
    }
}
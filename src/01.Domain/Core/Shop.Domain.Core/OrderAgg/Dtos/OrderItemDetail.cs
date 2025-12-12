using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Core.OrderAgg.Dtos
{
    public class OrderItemDetail
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
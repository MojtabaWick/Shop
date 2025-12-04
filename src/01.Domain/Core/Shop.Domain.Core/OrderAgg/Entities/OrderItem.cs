using Shop.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Core._Common;

namespace Shop.Domain.Core.OrderAgg.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
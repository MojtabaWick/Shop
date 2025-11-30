using Shop.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Core._Common;

namespace Shop.Domain.Core.CategoryAgg.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        // Navigation
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
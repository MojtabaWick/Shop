using Shop.Domain.Core.Enums;
using Shop.Domain.Core.OrderAgg.Entities;
using Shop.Domain.Core.ProductAgg.Entities;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Domain.Core.OrderAgg.Dtos
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }

        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderItemDetail> OrderItems { get; set; }
    }
}
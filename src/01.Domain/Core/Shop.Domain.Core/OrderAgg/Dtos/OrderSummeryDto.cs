using Shop.Domain.Core.Enums;

namespace Shop.Domain.Core.OrderAgg.Dtos
{
    public class OrderSummeryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }

        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
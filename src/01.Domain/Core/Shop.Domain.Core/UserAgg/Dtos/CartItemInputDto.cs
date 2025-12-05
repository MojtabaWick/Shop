namespace Shop.Domain.Core.UserAgg.Dtos
{
    public class CartItemInputDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
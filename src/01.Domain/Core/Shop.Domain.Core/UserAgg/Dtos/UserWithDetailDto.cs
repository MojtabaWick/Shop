namespace Shop.Domain.Core.UserAgg.Dtos
{
    public class UserWithDetailDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal WalletBalance { get; set; }
    }
}
using Shop.Domain.Core._Common;
using Shop.Domain.Core.Enums;
using Shop.Domain.Core.OrderAgg.Entities;

namespace Shop.Domain.Core.UserAgg.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal WalletBalance { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;

        // Navigation Properties
        public List<CartItem> CartItems { get; set; } = [];

        public List<Order> Orders { get; set; } = [];
    }
}
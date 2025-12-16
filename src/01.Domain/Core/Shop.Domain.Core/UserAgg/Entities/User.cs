using Microsoft.AspNetCore.Identity;
using Shop.Domain.Core._Common;
using Shop.Domain.Core.Enums;
using Shop.Domain.Core.OrderAgg.Entities;

namespace Shop.Domain.Core.UserAgg.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? PostalCode { get; set; }
        public decimal WalletBalance { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;

        // Navigation Properties
        public List<CartItem> CartItems { get; set; } = [];

        public List<Order> Orders { get; set; } = [];
    }
}
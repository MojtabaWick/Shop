using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Core.Enums;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Infrastructure.EFCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.WalletBalance)
                .HasPrecision(18, 0);

            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.HasQueryFilter(x => !x.IsDeleted);

            // ===================== SEED DATA =====================

            PasswordHasher<IdentityUser<int>> passwordHasher = new PasswordHasher<IdentityUser<int>>();

            var user1 = new ApplicationUser
            {
                Id = 1,
                UserName = "09111111111",
                NormalizedUserName = "09111111111",
                PhoneNumber = "09111111111",
                FullName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                Address = "کرج",
                WalletBalance = 0,
                Role = UserRole.Admin,
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false,
                SecurityStamp = new string(Guid.NewGuid().ToString()),
                ConcurrencyStamp = new string(Guid.NewGuid().ToString()),
            };
            user1.PasswordHash = passwordHasher.HashPassword(user1, "1234");

            var user2 = new ApplicationUser
            {
                Id = 2,
                UserName = "09038230353",
                NormalizedUserName = "09038230353",
                PhoneNumber = "09038230353",
                FullName = "مجتبی ملاعبداللهی",
                Address = "کرج",
                WalletBalance = 100000000,
                Role = UserRole.Customer,
                CreatedAt = new DateTime(2024, 1, 1),
                SecurityStamp = new string(Guid.NewGuid().ToString()),
                ConcurrencyStamp = new string(Guid.NewGuid().ToString()),
            };

            user2.PasswordHash = passwordHasher.HashPassword(user2, "1234");

            builder.HasData(user1, user2);
        }
    }
}
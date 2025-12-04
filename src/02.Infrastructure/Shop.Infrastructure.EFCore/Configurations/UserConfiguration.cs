using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Core.Enums;
using Shop.Domain.Core.UserAgg.Entities;

namespace Shop.Infrastructure.EFCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .HasMaxLength(200);

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.WalletBalance)
                .HasPrecision(18, 0);

            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.HasData(new List<User>
            {
                new User(){Id = 1 ,
                    FullName = "admin" ,
                    Address = "کرج" ,Password = "1234" ,
                    PhoneNumber = "09111111111",
                    WalletBalance = 0,
                    Role = UserRole.Admin,
                },
                new User(){Id = 2 ,
                    FullName = "مجتبی ملاعبداللهی" ,
                    Address = "کرج" ,Password = "1234" ,
                    PhoneNumber = "09038230353",
                    WalletBalance = 100000000,
                    Role = UserRole.Customer,
                },
                new User(){Id = 3 ,
                    FullName = "امیر امیریگانه" ,
                    Address = "تهران" ,Password = "1234" ,
                    PhoneNumber = "09128230353",
                    WalletBalance = 80000000,
                    Role = UserRole.Customer,
                },
                new User(){Id = 4 ,
                    FullName = "علی روشنی" ,
                    Address = "تهران" ,Password = "1234" ,
                    PhoneNumber = "09338330353",
                    WalletBalance = 6666000,
                    Role = UserRole.Customer,
                },
            });
        }
    }
}
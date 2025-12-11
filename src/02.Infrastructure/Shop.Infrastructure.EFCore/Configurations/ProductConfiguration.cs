using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Shop.Infrastructure.EFCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Price)
                .HasPrecision(18, 0);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(p => !p.IsDeleted);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Product>()
            {
                new Product(){Id = 1 ,
                    CategoryId = 1 ,
                    Title = "تلویزیون سونی x55k" ,
                    Description = "تلویزون سونی 55 اینچ سه بعدی ، نمایشگر full hd." ,
                    Price = 55000000,
                    Stock = 20 ,
                    ImageUrl = "/Images/Products/x55k.jpg"
                },
                new Product(){Id = 2 ,
                    CategoryId = 1 ,
                    Title = "تلویزیون سونی xr70" ,
                    Description = "تلویزون سونی 65 اینچ ، نمایشگر ultra hd." ,
                    Price = 70000000,
                    Stock = 5 ,
                    ImageUrl = "/Images/Products/xr70.jpg"
                },
                new Product(){Id = 3 ,
                    CategoryId = 1 ,
                    Title = "تلویزیون ال جی s30" ,
                    Description = "تلویزون ال جی 85 اینچ ، نمایشگر ultra hd." ,
                    Price = 87000000,
                    Stock = 10 ,
                    ImageUrl = "/Images/Products/s30.jpg"
                },
                new Product(){Id = 4 ,
                    CategoryId = 1 ,
                    Title = "تلویزیون سامسونگ x55ks" ,
                    Description = "تلویزون سامسونگ 55 اینچ ، نمایشگر ultra hd." ,
                    Price = 65000000,
                    Stock = 15 ,
                    ImageUrl = "/Images/Products/x55k.jpg"
                },
                new Product(){Id = 5 ,
                    CategoryId = 2 ,
                    Title = "موبایل سامسونگ A53" ,
                    Description = "موبایل سامسونگ A53 به همراه گارانتی دو ساله" ,
                    Price = 30000000,
                    Stock = 30 ,
                    ImageUrl = "/Images/Products/A30.jpg"
                },
                new Product(){Id = 6 ,
                    CategoryId = 2 ,
                    Title = "موبایل شیائومی پوکو" ,
                    Description = "گوشی موبایل شیائومی پوکو با دوربین ultra hd" ,
                    Price = 50000000,
                    Stock = 20 ,
                    ImageUrl = "/Images/Products/poco.jpg"
                },
                new Product(){Id = 7 ,
                    CategoryId = 2 ,
                    Title = "iphone 17" ,
                    Description = "گوشی موبایل آیفون 17 ساخت شرکت اپل . سال ساخت 1404" ,
                    Price = 170000000,
                    Stock = 17 ,
                    ImageUrl = "/Images/Products/iphone17.jpg"
                },
                new Product(){Id = 8 ,
                    CategoryId = 2 ,
                    Title = "s25fe" ,
                    Description = "گوشی موبایل سامسونگ s25fe" ,
                    Price = 55000000,
                    Stock = 20 ,
                    ImageUrl = "/Images/Products/s25fe.jpg"
                },
            });
        }
    }
}
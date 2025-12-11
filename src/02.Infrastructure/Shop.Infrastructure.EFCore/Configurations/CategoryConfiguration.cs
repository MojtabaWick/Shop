using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Core.CategoryAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.EFCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(new List<Category>()
            {
                new Category(){Id = 1 , Name = "تلویزیون" },
                new Category(){Id = 2 , Name = "موبایل" },
            });
        }
    }
}
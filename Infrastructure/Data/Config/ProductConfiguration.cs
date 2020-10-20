using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(P => P.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(P => P.PictureUrl).IsRequired();
            
            builder.HasOne(b => b.ProductBrand)
                .WithMany()
                .HasForeignKey(prop => prop.ProductBrandId);
            
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(prop => prop.ProductTypeId);
        }
    }
}

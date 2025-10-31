using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteDev.Ecommerc.Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Data.Configuration.Products
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(100);

             builder.Property(p => p.Description)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(8,2)");

            builder.HasOne(p => p.Brand)
                   .WithMany()
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Type)
                     .WithMany()
                     .HasForeignKey(p => p.TypeId)
                     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RouteDev.Ecommerc.Presistance.Data.Configuration.Order
{
    internal class OrderConfig : IEntityTypeConfiguration<RouteDev.Ecommerc.Domain.Entites.Orders.Order>
    {
       

        public void Configure(EntityTypeBuilder<Domain.Entites.Orders.Order> builder)
        {
            builder.ToTable("Orders");

            builder.Property(D => D.SubTotal)
                   .HasColumnType("decimal(8,2)");

            builder.HasMany(O => O.Items)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(O => O.DeliveryMethod)
                .WithMany()
                .HasForeignKey(O => O.DeliveryMethodId);

            builder.OwnsOne(O => O.ShippingAddress);
        }
    }
}

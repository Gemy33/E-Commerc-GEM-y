using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Identity.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.ToTable("Addresses");
        }
    }
}

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
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.DisplayName).IsRequired();
            builder.HasOne(u => u.Address)
                   .WithOne()
                   .HasForeignKey<Address>(A => A.UserId)
                   .OnDelete(DeleteBehavior.Cascade)    
                   .IsRequired(false);
        }
    }
}

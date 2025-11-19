using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
using RouteDev.Ecommerc.Presistance.Identity.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Identity
{
    public class StoreIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserConfig());
            builder.ApplyConfiguration(new AddressConfig());


        }
    }
}

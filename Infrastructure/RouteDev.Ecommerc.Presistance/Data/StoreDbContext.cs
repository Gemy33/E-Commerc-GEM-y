using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Presistance.Data.Configuration.Order;
using RouteDev.Ecommerc.Presistance.Data.Configuration.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Data
{
    public class StoreDbContext:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> productBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new ProductConfig() );
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new DeliveryMethodConfig());

            modelBuilder.ApplyConfiguration(new OrderItemConfig());


        }
    }
}

using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Domain.Entites.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Data
{
    public  class StoreDbIntilizer(StoreDbContext context) : Intializer
    {
        public  async Task InitializeAsync()
        {
            var pendingMigrations =  await context.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await context.Database.MigrateAsync();
            }

        }

        public async Task SeedDataAsync()
        {
            if (!context.productBrands.Any())
            {
                var brands = await File.ReadAllTextAsync("../infrastructure/RouteDev.Ecommerc.Presistance/Data/DataSeeds/brands.json");
                var deserializedBrands =  JsonSerializer.Deserialize<List<ProductBrand>>(brands);
                if (deserializedBrands?.Count > 0)
                {
                    await context.productBrands.AddRangeAsync(deserializedBrands);
                    await context.SaveChangesAsync();
                }
            }
            if (!context.productTypes.Any())
            {
                var brands =await File.ReadAllTextAsync("../infrastructure/RouteDev.Ecommerc.Presistance/Data/DataSeeds/types.json");
                var deserializedBrands =  JsonSerializer.Deserialize<List<ProductType>>(brands);
                if (deserializedBrands?.Count > 0)
                {
                    await context.productTypes.AddRangeAsync(deserializedBrands);
                    await context.SaveChangesAsync();
                }
            }
            if (!context.products.Any())
            {
                var brands = await File.ReadAllTextAsync("../infrastructure/RouteDev.Ecommerc.Presistance/Data/DataSeeds/products.json");
                var deserializedBrands = JsonSerializer.Deserialize<List<Product>>(brands);
                if (deserializedBrands?.Count > 0)
                {
                    await context.products.AddRangeAsync(deserializedBrands);
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}

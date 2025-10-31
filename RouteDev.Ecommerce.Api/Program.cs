
using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Presistance.Data.Context;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteDev.Ecommerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    )

                );

            var app = builder.Build();
            #region
            var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var context = service.GetRequiredService<AppDbContext>();
            var logger = service.GetRequiredService<ILogger<Program>>();
            try
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    await context.Database.MigrateAsync();
                }

                #region Seed Brand
                if (!context.productBrands.Any())
                {
                    var brands = File.ReadAllText("../infrastructure/RouteDev.Ecommerc.Presistance/Data/DataSeeds/brands.json");
                    var deserializedBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brands);
                    if (deserializedBrands?.Count > 0)
                    {
                        await context.productBrands.AddRangeAsync(deserializedBrands);
                        await context.SaveChangesAsync();
                    }
                }
                if (!context.productTypes.Any())
                {
                    var brands = File.ReadAllText("../infrastructure/RouteDev.Ecommerc.Presistance/Data/DataSeeds/types.json");
                    var deserializedBrands = JsonSerializer.Deserialize<List<ProductType>>(brands);
                    if (deserializedBrands?.Count > 0)
                    {
                        await context.productTypes.AddRangeAsync(deserializedBrands);
                        await context.SaveChangesAsync();
                    }
                }
                if (!context.products.Any())
                {
                    var brands = File.ReadAllText("../infrastructure/RouteDev.Ecommerc.Presistance/Data/DataSeeds/products.json");
                    var deserializedBrands = JsonSerializer.Deserialize<List<Product>>(brands);
                    if (deserializedBrands?.Count > 0)
                    {
                        await context.products.AddRangeAsync(deserializedBrands);
                        await context.SaveChangesAsync();
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message, "error occuer during migration or seeding");
            }
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

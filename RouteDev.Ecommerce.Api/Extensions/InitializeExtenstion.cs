using RouteDev.Ecommerc.Domain.Contracts;
using RouteDev.Ecommerc.Presistance.Data.Context;
using RouteDev.Ecommerce.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Extensions
{
    public static class InitializeExtenstion
    {
        public async static Task<WebApplication> InitializeExtenstionAsync(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var logger = service.GetRequiredService<ILogger<Program>>();
            var intializer = service.GetRequiredService<Intializer>();

            try
            {

                await intializer.InitializeAsync();
                await intializer.SeedDataAsync();


            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message, "error occuer during migration or seeding");
            }
            return app;
        }
    }
}

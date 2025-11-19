using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerce.Api;

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
            var context = service.GetRequiredService<IStorIdentityDbInitalizer>();

            try
            {

                await intializer.InitializeAsync();
                await intializer.SeedDataAsync();
                await context.InitializeAsync();
                await context.SeedDataAsync();


            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message, "error occuer during migration or seeding");
            }
            return app;
        }
    }
}

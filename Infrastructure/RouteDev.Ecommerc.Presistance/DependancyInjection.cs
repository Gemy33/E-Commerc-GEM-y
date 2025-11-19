using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Presistance.Data;
using RouteDev.Ecommerc.Presistance.Identity;
using RouteDev.Ecommerc.Presistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance
{
    public static class DependancyInjection
    {

        public static IServiceCollection AddPresistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(
                options => options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection")
                    )
                );
            services.AddScoped<IStorIdentityDbInitalizer, StorIdetityDbIntializer>();

            services.AddScoped<Intializer, StoreDbIntilizer>();
            services.AddScoped<IUnitOfWork, UniteOfWork>();

            return services;
        }
    }
}

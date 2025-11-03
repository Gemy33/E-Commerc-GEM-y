using Microsoft.Extensions.DependencyInjection;
using RouteDev.Ecommerc.Domain.Contracts;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using RouteDev.Ecommerc.Services.Mapping;
using RouteDev.Ecommerc.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            //services.AddAutoMapper( p => p.AddProfile(new MappingProfile()));
            services.AddAutoMapper( p => p.AddProfile(typeof(MappingProfile)));
            services.AddScoped<IserviceManager,ServiceManager>();
            services.AddTransient<ProductUrlResolver>();
            return services;
        }
    }
}

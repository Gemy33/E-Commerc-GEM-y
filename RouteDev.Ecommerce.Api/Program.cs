
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Contracts;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Presistance;
using RouteDev.Ecommerc.Presistance.Data;
using RouteDev.Ecommerc.Presistance.Data.Context;
using RouteDev.Ecommerc.Presistance.Extensions;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using RouteDev.Ecommerc.Services;
using RouteDev.Ecommerce.Api.CustemMiddleware;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteDev.Ecommerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers()
                             .AddApplicationPart(typeof(BaseController).Assembly);


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(e => e.Value!.Errors.Count > 0)
                                                          .Select(c => new Error()
                                                          {
                                                              Feild = c.Key,
                                                              Errors = c.Value!.Errors.Select(e => e.ErrorMessage)
                                                          });
                    var response = new ValidatioinErrors()
                    {
                        Errors = errors
                    };
                    var result = new BadRequestObjectResult(response);
                    result.ContentTypes.Add("application/json");
                    return result;


                };
            });
            builder.Services.AddPresistanceServices(builder.Configuration);
            builder.Services.AddServiceServices();
            var app = builder.Build();
             app.UseMiddleware<ExceptionHandlingMiddleware>();


            await app.InitializeExtenstionAsync();

            #region configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}

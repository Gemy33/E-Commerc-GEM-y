
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Presistance;
using RouteDev.Ecommerc.Presistance.Extensions;
using RouteDev.Ecommerc.Presistance.Identity;
using RouteDev.Ecommerc.Presistance.Repository;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using RouteDev.Ecommerc.Services;
using RouteDev.Ecommerce.Api.CustemMiddleware;
using StackExchange.Redis;
using System.Text;

namespace RouteDev.Ecommerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers()
                             .AddApplicationPart(typeof(BaseController).Assembly);
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

            builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("IdentitytConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>((identityOptions) =>
            {
                #region password
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequiredLength = 6;
                #endregion

                identityOptions.User.RequireUniqueEmail = true;
                //identityOptions.User.AllowedUserNameCharacters = "sd";

                identityOptions.SignIn.RequireConfirmedEmail = false;
                identityOptions.SignIn.RequireConfirmedPhoneNumber = false;
                identityOptions.SignIn.RequireConfirmedAccount = false;

                identityOptions.Lockout.AllowedForNewUsers = true;
                identityOptions.Lockout.MaxFailedAccessAttempts = 5;
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);




            }).AddEntityFrameworkStores<StoreIdentityDbContext>();

            builder.Services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = "Bearer";
                authOptions.DefaultChallengeScheme = "Bearer";



            }).AddJwtBearer(_ =>
            {
                _.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            }); 

            #region cofigure redis 
            //builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            //{
            //    var configuration = builder.Configuration.GetSection("Redis")["ConnectionStringForRedis"]!;
            //    return ConnectionMultiplexer.Connect(configuration);
            //});
            builder.Services.AddSingleton(typeof(IConnectionMultiplexer), (_) =>
            {
                var configuration = builder.Configuration.GetSection("Redis")["ConnectionStringForRedis"]!;

                return ConnectionMultiplexer.Connect(configuration);
            });

            builder.Services.AddScoped(typeof(IBasket), typeof(BasketRepo));

            #endregion
            //        builder.Services.AddDbContext<StoreIdentityDbContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("IdentitytConnection")));


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
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}

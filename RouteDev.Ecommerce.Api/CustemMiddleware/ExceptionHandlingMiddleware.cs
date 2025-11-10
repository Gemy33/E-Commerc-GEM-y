using Microsoft.AspNetCore.Http;
using RouteDev.Ecommerc.Domain.Exceptions.NotFound;
using RouteDev.Ecommerc.Service.Apstraction.Common;

namespace RouteDev.Ecommerce.Api.CustemMiddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {

            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    throw new NotFoundException("The requested resource was not found.");
                }
            }
            catch (Exception ex)
            {
                int statusCode;
                ApiErrorRespons res;

                context.Response.StatusCode = ex switch
                {
                    NotFoundException => statusCode= StatusCodes.Status404NotFound,
                    
                    _ => statusCode =  StatusCodes.Status500InternalServerError,
                };
                context.Response.ContentType = "application/json";
                var response = new ApiErrorRespons(statusCode, ex.Message);

                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}

using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using RouteDev.Ecommerc.Domain.Exceptions.Basket;
using RouteDev.Ecommerc.Domain.Exceptions.NotFound;
using RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using System.Text.Json;

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
                    throw new ProductException("The requested resource was not found.",404);
                }
            }
            catch (Exception ex)
            {
                // log exception
                // handle exceptions
                await HandleExceptionAsync(context, ex);

            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            ApiErrorRespons response = new();


            int status = ex switch
            {
                AuthException auth => auth.statusCode,
                ProductException product => product.StatusCode,
                BasketException basket => basket.StutasCode,
                _ => 500

            };
            response.StatusCode = status;
            response.Error = ex.Message;
        

            context.Response.StatusCode = status;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));

        }
    }
}

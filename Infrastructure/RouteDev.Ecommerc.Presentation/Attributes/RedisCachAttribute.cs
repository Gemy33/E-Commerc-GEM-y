using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presentation.Attributes
{
   
    public class RedisCachAttribute(int TimeToLiveInSec = 1200 ) :ActionFilterAttribute
    {
        

        
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cachKey = GenerateCachKeyFromRequest(context);
            var service = context.HttpContext.RequestServices.GetRequiredService<ICachService>();

            var cachValue = await service.GetValueAsync(cachKey);
            if(cachValue != null)
            {
                context.Result = new ContentResult()
                {
                    Content = cachValue,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                return;
            }
            var executedContext = await next();
            if(executedContext.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                await service.SetValueAsync(cachKey, objectResult.Value, TimeSpan.FromSeconds(TimeToLiveInSec));
            }

        }

        private  string GenerateCachKeyFromRequest(ActionExecutingContext context)
        {
            var cachBuilder = new StringBuilder();
            var bathUrl = context.HttpContext.Request.Path;
            cachBuilder.Append(bathUrl);
            foreach (var item in context.HttpContext.Request.Query.OrderBy(q => q.Key))
                cachBuilder.Append($"&{item.Key}={item.Value}");
            return cachBuilder.ToString();
        }
    }
}

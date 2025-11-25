using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services.Services
{
    internal class CachService(ICachRepo cachRepo): ICachService
    {

       

        public Task<string?> GetValueAsync(string key) => cachRepo.GetValueAsync(key);



        public Task SetValueAsync(string key, object value, TimeSpan TTL) => cachRepo.SetValueAsync(key, value, TTL);
      
    }
}

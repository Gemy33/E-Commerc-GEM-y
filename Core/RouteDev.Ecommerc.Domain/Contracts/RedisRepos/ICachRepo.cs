using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Contracts.RedisRepos
{
    public interface ICachRepo
    {
        public Task SetValueAsync(string key , object value , TimeSpan TTL);
        public Task<string?> GetValueAsync(string key);
    }
}

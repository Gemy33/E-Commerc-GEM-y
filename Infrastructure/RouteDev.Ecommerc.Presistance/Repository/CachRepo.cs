using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Repository
{
    public class CachRepo : ICachRepo
    {
        readonly IDatabase _database;
        public CachRepo(IConnectionMultiplexer multiplexer)
        {
            _database = multiplexer.GetDatabase();

        }
        public async Task<string?> GetValueAsync(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.IsNullOrEmpty) return null;
            return value;
        }

        public Task SetValueAsync(string key, object value, TimeSpan TTL)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            return _database.StringSetAsync(key, serializedValue, TTL);
        }
    }
}

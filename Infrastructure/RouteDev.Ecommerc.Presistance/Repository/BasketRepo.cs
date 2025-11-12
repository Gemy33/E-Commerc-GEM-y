using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Domain.Entites.Baskets;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Repository
{
    public class BasketRepo : IBasket
    {
        private readonly IDatabase _database;
        public BasketRepo(IConnectionMultiplexer multiplexer) // context for redis
        {
            _database = multiplexer.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public  async Task<Basket?>GetBasketAsync(string basketId)
        {
            var basket =  await _database.StringGetAsync(basketId);
            if (basket.IsNullOrEmpty)
                return null;
            var res = JsonSerializer.Deserialize<Basket>(basket);
            return res;

        }

        public async Task<Basket?> UpdateBasketAsync(Basket basket,TimeSpan? keepToLive)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),keepToLive);
            if (!created)
                return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}

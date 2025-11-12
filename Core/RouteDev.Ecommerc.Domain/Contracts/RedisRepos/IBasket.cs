using RouteDev.Ecommerc.Domain.Entites.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Contracts.RedisRepos
{
    public interface IBasket
    {
        Task<Basket?> GetBasketAsync(string basketId);
        Task<Basket?> UpdateBasketAsync(Basket basket, TimeSpan? keepToLive);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}

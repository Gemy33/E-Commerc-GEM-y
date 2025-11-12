using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Services
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string basketId);
        Task<BasketDto> UpdateBasketAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string basketId);
        public  Task<BasketDto?> RemoveItemFromBasketAsync(string basketId, int itemId);
        public  Task<BasketDto?> AddItemToBasketAsync(string basketId, BasketItemDto basketItemDto);
    }
}

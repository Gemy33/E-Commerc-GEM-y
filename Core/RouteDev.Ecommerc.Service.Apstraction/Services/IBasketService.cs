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
      
        Task<BasketDto> GetBasketAsync(string userId, string basketId);
        Task<BasketDto> UpdateItemQuantityAsync(string basketId, string userId, int itemId, int quantity);
        Task<BasketDto> UpdateBasketAsync(string userId, UpdataBaskeRequestDto basketdto);
        Task<bool> DeleteBasketAsync(string userId, string basketId);
        Task<BasketDto?> RemoveItemFromBasketAsync(string userId, string basketId, int itemId);
        Task<BasketDto?> AddItemToBasketAsync(string userId, string basketId, BasketItemDto basketItemDto);
    }
}

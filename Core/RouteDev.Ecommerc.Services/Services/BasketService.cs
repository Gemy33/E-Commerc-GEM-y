using AutoMapper;
using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Domain.Entites.Baskets;
using RouteDev.Ecommerc.Domain.Exceptions.Basket;
using RouteDev.Ecommerc.Domain.Exceptions.NotFound;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services.Services
{
    internal class BasketService : IBasketService
    {
        private readonly IBasket _basket;
        private readonly IMapper _mapper;

        public BasketService(IBasket basket, IMapper mapper)
        {
            _basket = basket;
            _mapper = mapper;
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _basket.DeleteBasketAsync(basketId);
        }

        public async Task<BasketDto?> RemoveItemFromBasketAsync(string basketId, int itemId)
        {
            var existingBasket = await _basket.GetBasketAsync(basketId);
            if (existingBasket is not null)
            {
                var theItmeInBaske = existingBasket.Items.FirstOrDefault(i => i.Id == itemId);

                if (theItmeInBaske is not null)
                {
                    existingBasket.Items.Remove(theItmeInBaske);
                    var dfd = _mapper.Map<BasketDto>(existingBasket);
                    return await UpdateBasketAsync(dfd);


                }
                else throw new BasketEmptyException();

            }
            else
                throw new BasketNotFoundException();



        }

        public async Task<BasketDto> GetBasketAsync(string basketId)
        {
            var deletedBasket = await _basket.GetBasketAsync(basketId);
            if (deletedBasket is null)
                throw new BasketNotFoundException();
            var mappedBasket = _mapper.Map<BasketDto>(deletedBasket);
            return mappedBasket;
        }


        public async Task<BasketDto?> AddItemToBasketAsync(string basketId, BasketItemDto basketItemDto)
        {
            var basket = await GetBasketAsync(basketId) ?? new BasketDto { Id = basketId };
            var existsItem = basket.Items.FirstOrDefault(i => i.Id == basketItemDto.Id);
            if (existsItem is not null)
            {
                existsItem.Quantity += basketItemDto.Quantity;
            }
            else
            {
                var mappedItem = _mapper.Map<BasketItemDto>(basketItemDto);
                basket.Items.Add(mappedItem);

            }
            return await UpdateBasketAsync(basket);



        }


        public async Task<BasketDto> UpdateBasketAsync(BasketDto basketdto)
        {
            var returndBasket = await _basket.UpdateBasketAsync(_mapper.Map<Basket>(basketdto), TimeSpan.FromDays(30));
            if (returndBasket is null)
                throw new Exception("problem in update basket");
            var mappedBasket = _mapper.Map<BasketDto>(returndBasket);
            return mappedBasket;


        }
    }
}

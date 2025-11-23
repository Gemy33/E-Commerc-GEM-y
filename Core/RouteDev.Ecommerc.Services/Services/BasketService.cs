using AutoMapper;
using Microsoft.Extensions.Logging;
using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Domain.Entites.Baskets;
using RouteDev.Ecommerc.Domain.Exceptions.Basket;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket;
using RouteDev.Ecommerc.Service.Apstraction.Services;

namespace RouteDev.Ecommerc.Services.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasket _basket;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BasketService(IBasket basket, IMapper mapper , ILogger<BasketService> logger)
        {
            _basket = basket;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> DeleteBasketAsync(string userId, string basketId)
        {

            ValidateUserId(userId);
            ValidateBasketId(basketId);
            var existingBasket = await _basket.GetBasketAsync(basketId);
            if(existingBasket is not null && userId != existingBasket.UserId)
                throw new UnauthorizedBasketAccessException();

            var result =  await _basket.DeleteBasketAsync(basketId);
            if(result)
                _logger.LogInformation($"Successfully deleted basket {basketId}", basketId);
            else
                _logger.LogInformation($"Basket {basketId} was not found for deletion", basketId);
            return result;

        }  // done

        public async Task<BasketDto?> RemoveItemFromBasketAsync(string userId, string basketId, int itemId)
        {
            ValidateBasketId(basketId);
            ValidateUserId(userId);

            var existingBasket = await _basket.GetBasketAsync(basketId);

            if (existingBasket is not null)
            {
                var theItmeInBaske = existingBasket.Items.FirstOrDefault(i => i.Id == itemId);

                if (theItmeInBaske is not null)
                {
                    existingBasket.Items.Remove(theItmeInBaske);
                    var basketToUpdata = _mapper.Map<UpdataBaskeRequestDto>(existingBasket);
                    return await UpdateBasketAsync(userId, basketToUpdata);


                }
                else throw new BasketEmptyException(itemId);

            }
            else
                throw new BasketNotFoundException();



        } // done

        public async Task<BasketDto> GetBasketAsync(string userId,  string basketId)
        {
            ValidateBasketId(basketId);
            ValidateUserId(userId);

            var ExistingBasket = await _basket.GetBasketAsync(basketId);

            if (ExistingBasket is null)
                throw new BasketNotFoundException();

            if (ExistingBasket is not null && userId != ExistingBasket.UserId)
                throw new UnauthorizedBasketAccessException();

            return _mapper.Map<BasketDto>(ExistingBasket);
        }  // done


        public async Task<BasketDto?> AddItemToBasketAsync(string userId, string basketId, BasketItemDto basketItemDto)
        {
            ValidateBasketId(basketId);
            ValidateUserId(userId);
            // validate basket item dto
            BasketDto basket;
            var existingBasket = await _basket.GetBasketAsync(basketId);
            if(existingBasket is null)
            {
                basket = new BasketDto()
                {
                    Id = basketId,
                    UserId = userId,
                };
            }
            else
            {
                if (existingBasket.UserId != userId)
                    throw new UnauthorizedBasketAccessException();
                basket = _mapper.Map<BasketDto>(existingBasket);
            }
            var existsItem = basket.Items.FirstOrDefault(i => i.Id == basketItemDto.Id);
            if (existsItem is not null)
            {
                // if exist validation for max quantity can be added here
                existsItem.Quantity += basketItemDto.Quantity;
            }
            else
            {
                basket.Items.Add(basketItemDto);
            }

            // if exist validation for total items and total price can be added here

            return await UpdataBasketInternally(basket);

           



        }


        public async Task<BasketDto> UpdateBasketAsync(string userId, UpdataBaskeRequestDto basketdto)
        {
            ValidateUserId(userId);

            if (basketdto == null)
                throw new ArgumentNullException(nameof(basketdto));

            ValidateBasketId(basketdto.BasketId);

            var basket = await _basket.GetBasketAsync(basketdto.BasketId);

            if (basket == null)
            {
                basket = new Basket
                {
                    Id = basketdto.BasketId,
                    Items = new List<BasketItem>(),
                    UserId = userId

                };
                basket.Items = _mapper.Map<List<BasketItem>>(basketdto.Items);
            }
            else
            {
                basket.Items = _mapper.Map<List<BasketItem>>(basketdto.Items);
                
            }


            var mappedBAsket = _mapper.Map<BasketDto>(basket);
            if (mappedBAsket.UserId != userId)
            {
                throw new UnauthorizedBasketAccessException();
            }
            if (basketdto.Items.Count > 20) // Example limit for number of items 20 is hardcoded for demo purposes
            {
                throw new BasketLimitExceededException(mappedBAsket.Id);
            }

            if (mappedBAsket.TotalPrice > 20000)  // Example limit for total price 20000 is hardcoded for demo purposes
            {
                throw new BasketLimitExceededException(mappedBAsket.Id);
            }

            return await UpdataBasketInternally(mappedBAsket);

        } // done

        public async Task<BasketDto> UpdateItemQuantityAsync(string basketId, string userId, int itemId, int quantity)
        {
            ValidateUserId(userId);
            ValidateBasketId(basketId);
            var existingBasket = await _basket.GetBasketAsync(basketId);
            if(existingBasket is not null)
            {
                if(existingBasket.UserId != userId)
                    throw new UnauthorizedBasketAccessException();
                var item = existingBasket.Items.FirstOrDefault(i => i.Id == itemId);
                if(item is not null)
                {
                    item.Quantity = quantity;
                    var basketToUpdata = _mapper.Map<BasketDto>(existingBasket);
                    return await UpdataBasketInternally(basketToUpdata);
                }
                else
                {
                    throw new BasketEmptyException(itemId);
                }
            }
            else
            {
                throw new BasketNotFoundException();
            }
        }

        // helpter method
        private async Task<BasketDto> UpdataBasketInternally(BasketDto basketdto)
        {
            var returndBasket = await _basket.UpdateBasketAsync(_mapper.Map<Basket>(basketdto), TimeSpan.FromDays(30));
            if (returndBasket is null)
                throw new BasketUpdateException();
            var mappedBasket = _mapper.Map<BasketDto>(returndBasket);
            return mappedBasket;
        }

        private void ValidateBasketId(string basketId)
        {
            if (string.IsNullOrWhiteSpace(basketId))
            {
                throw new ArgumentException("Basket ID cannot be null or empty", nameof(basketId));
            }

            if (basketId.Length > 100)
            {
                throw new ArgumentException("Basket ID cannot exceed 100 characters", nameof(basketId));
            }
        }

        private void ValidateUserId(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("User ID cannot be null or empty", nameof(userId));
            }
        }
    }
}

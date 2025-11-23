using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RouteDev.Ecommerc.Presentation.Controllers.Basket
{
    [Authorize]
    public class BasketController : BaseController
    {
        private readonly IserviceManager _iserviceManager;
        public BasketController(IserviceManager iserviceManager)
        {
            this._iserviceManager = iserviceManager;
        }
        [HttpPost("{basketId}")]
        private string GetUserId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }

        [HttpPost("{basketId}/items")]

        public async Task<IActionResult> AddItemToBasketAsync(string basketId, [FromBody] BasketItemDto itemDto)
        {
            var userId = GetUserId();
            var basket = await _iserviceManager.BasketService.AddItemToBasketAsync(userId, basketId, itemDto);
            return Ok(basket);
        }

        [HttpDelete("{basketId}/{productId}")]
        public async Task<IActionResult> RemoveItemFromBasketAsync(string basketId, int productId)
        {
            var userId = GetUserId();
            var basket = await _iserviceManager.BasketService.RemoveItemFromBasketAsync(userId, basketId, productId);
            return Ok(basket);
        }

        [HttpPost("{basketID}")]
        public async Task<IActionResult> CreateUpdateBasket([FromBody] UpdataBaskeRequestDto? requestDto, string basketID)
        {
            var userId = GetUserId();
            if (basketID != requestDto.BasketId)
                return BadRequest("Basket ID mismatch");

            //requestDto.UserId = userId;
            var basket = await _iserviceManager.BasketService.UpdateBasketAsync(userId, requestDto);
            return Ok(basket);
        }

        [HttpGet("{basketId}")]
        public async Task<IActionResult> GetBasket(string basketId)
        {
            var userId = GetUserId();
            var basket = await _iserviceManager.BasketService.GetBasketAsync(userId,basketId);
            return Ok(basket);
        }

        [HttpDelete("{basketId}")]
        public async Task<IActionResult> DeleteBasket(string basketId)
        {
            var userId = GetUserId();
            var result = await _iserviceManager.BasketService.DeleteBasketAsync(userId,basketId);
            return Ok(result);
        }

        [HttpPost("{basketId}/{productId}/{Quntity}")]
        public async Task<ActionResult> UpdataQuentity(string basketId ,int productId, int Quntity)
        {
            var userID = GetUserId();
            var updataedBasket = await _iserviceManager.BasketService.UpdateItemQuantityAsync(basketId,userID,productId, Quntity);
            return Ok(updataedBasket);
        }
    }
}

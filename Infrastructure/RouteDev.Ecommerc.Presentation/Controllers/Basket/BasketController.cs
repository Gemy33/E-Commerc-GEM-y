using Microsoft.AspNetCore.Mvc;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presentation.Controllers.Basket
{
    public class BasketController : BaseController
    {
        private readonly IserviceManager _iserviceManager;
        public BasketController(IserviceManager iserviceManager)
        {
            this._iserviceManager = iserviceManager;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult>AddItemToBasketAsync(string id , BasketItemDto itemDto)
        {
            var basket = await _iserviceManager.BasketService.AddItemToBasketAsync(id, itemDto);
            return Ok(basket);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItemFromBasketAsync(string id, int productId)
        {
            var basket = await _iserviceManager.BasketService.RemoveItemFromBasketAsync(id, productId);
            return Ok(basket);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdateBasket(BasketDto? basketDto)
        {
            var basket =await _iserviceManager.BasketService.UpdateBasketAsync(basketDto);
            return Ok(basket);
        }
        [HttpGet]
        [Route("{basketId}")]
        public async Task<IActionResult> GetBasketById(string basketId)
        {
            var basket = await _iserviceManager.BasketService.GetBasketAsync(basketId);
            return Ok(basket);
        }
        [HttpDelete]
        [Route("{basketId}")]
        public async Task<IActionResult> DeleteBasketById(string basketId)
        {
            var result = await _iserviceManager.BasketService.DeleteBasketAsync(basketId);
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Order;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presentation.Controllers.Order
{
    public class OrderController(IserviceManager serviceManager) : BaseController
    {

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateOrder(OrderDto request)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await serviceManager.OrderService.CreateOrder(request, email);
            return Ok(orders);


        }
        [HttpGet("DeliveryMethods")]
        [Authorize]

        public async Task<ActionResult> GetAllDeliveryMethods()
        {
            var AllMethods = await serviceManager.OrderService.GetAllDeliveryMethodAsync();
            return Ok(AllMethods);
        }
        [HttpGet]
        [Authorize]

        public async Task<ActionResult> GetAllOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await serviceManager.OrderService.GetAllOrdersAsync(email);
            return Ok(orders);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetOrderById(Guid id)
        {
           
            var order = await serviceManager.OrderService.GetOrderByIdAsync(id);
            return Ok(order);
        }


    }
}

using AutoMapper;
using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Domain.Entites.Orders;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Domain.Exceptions.NotFound;
using RouteDev.Ecommerc.Domain.Specifications.OrderSpecification;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Order;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services.Services
{
    public class OrderService(IUnitOfWork unitOfWork, IBasket basket, IMapper mapper) : IOrderService
    {
        public async Task<OrderResponseDto> CreateOrder(OrderDto dto, string email)
        {

            // 01 shippingAddress
            var shippingAdress = dto.ShipToAddress;
            var orderAddress = new OrderAddress()
            {
                City = shippingAdress.City,
                Country = shippingAdress.Cuntry,
                FirstName = shippingAdress.FirstName,
                LastName = shippingAdress.LastName,
                Street = shippingAdress.Street,
            };

            //02 Delivery Method
            var deliveryMethod = await unitOfWork.GetGenericRepoAsync<DeliveryMethod, int>().GetByIdAsync(dto.DeliveryMethodId);

            //03 getItems from basket but need to get it from database to check correcnese

            var items = await basket.GetBasketAsync(dto.BasketId);
            var orderItems = new List<OrderItem>();

            foreach (var item in items.Items)
            {
                Product product = await unitOfWork.GetGenericRepoAsync<Product, int>().GetByIdAsync(item.Id) ?? throw new ProductNotFound(item.Id);
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    Price = product.Price,
                    Product = new ProductOrderItem()
                    {
                        PictureUrl = product.PictureUrl,
                        ProductName = product.Name,
                        ProductId = product.Id,
                    }
                };
                orderItems.Add(orderItem);
            }

            var SubTotal = orderItems.Sum(i => i.Price * i.Quantity);



            var orderToAdd = new Order(email, orderAddress, deliveryMethod, orderItems, SubTotal);
            

            unitOfWork.GetGenericRepoAsync<Order, Guid>().Add(orderToAdd);
            await unitOfWork.CompleteAsync();

            return mapper.Map<OrderResponseDto>(orderToAdd);


        }

        public async Task<IEnumerable<DeliveryMethodDTo>> GetAllDeliveryMethodAsync()
        {
            var all = await unitOfWork.GetGenericRepoAsync<DeliveryMethod, int>().GetAllAsync();
            return mapper.Map<List<DeliveryMethodDTo>>(all);
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync(string Email)
        {
            var spec = new OrderSpecification();
            var orders = await unitOfWork.GetGenericRepoAsync<Order, Guid>().GetAllWithSpecsAsync(spec);
            return mapper.Map<List<OrderResponseDto>>(orders);
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(Guid id)
        {
            var spec = new OrderSpecification();
            var order = await unitOfWork.GetGenericRepoAsync<Order,Guid>().GetByIdAsyncWithSpecs(id,spec);
            return mapper.Map<OrderResponseDto>(order);
        }
    }
}

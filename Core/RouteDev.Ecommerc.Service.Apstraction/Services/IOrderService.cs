using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Services
{
    public interface IOrderService
    {
        public Task<OrderResponseDto> CreateOrder(OrderDto dto, string email);

        Task<IEnumerable<DeliveryMethodDTo>> GetAllDeliveryMethodAsync();

        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync(string Email);
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id);
    }
}

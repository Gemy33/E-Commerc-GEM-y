using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Order
{
    public class OrderResponseDto
    {
       
        public Guid Id { get; set; }
        public string buyerEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<OrderItemDto> Items { get; set; } = [];
        public AddressDto ShippingAddress { get; set; } = default!;
        public string DeliveryMethod { get; set; } = default!; // config mapping
        public string status { get; set; } = default!;
        public decimal SubTotal { get; set; }
        public decimal deliveryCost { get; set; }
        public decimal Total { get; set; }
    }
}

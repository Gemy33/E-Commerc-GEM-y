using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Orders
{
    public class Order:BaseEntity<Guid>
    {
        public Order()
        {
            
        }
        public Order(string buyerEmail, OrderAddress shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public string BuyerEmail { get; set; } = default!; //03
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderAddress ShippingAddress { get; set; } = null!;  //02
        public DeliveryMethod DeliveryMethod { get; set; } = default!; //01
        public int DeliveryMethodId { get; set; } //x
        public OrderStatus Status { get; set; }  //x
        public ICollection<OrderItem> Items { get; set; } = []; //05

        public decimal SubTotal { get; set; } //04


        //public decimal Total => SubTotal + DeliveryMethod.Cost;
        public decimal Total() => SubTotal + DeliveryMethod?.Cost ?? 0; //x




    }
}

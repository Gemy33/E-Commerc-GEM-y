using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public ProductOrderItem Product { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }


    }
}

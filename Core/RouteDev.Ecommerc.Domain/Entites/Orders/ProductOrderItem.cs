using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Orders
{
    public class ProductOrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
    }
}

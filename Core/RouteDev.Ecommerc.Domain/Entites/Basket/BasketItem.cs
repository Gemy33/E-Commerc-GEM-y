using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Baskets
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }

    }
}

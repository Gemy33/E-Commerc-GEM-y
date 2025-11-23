using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Baskets
{
    public class Basket
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ICollection<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}

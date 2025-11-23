using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket
{
    public class BasketDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ICollection<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
        public decimal TotalPrice => Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0;
        public int TotalItems => Items?.Sum(i => i.Quantity) ?? 0;

    }
}

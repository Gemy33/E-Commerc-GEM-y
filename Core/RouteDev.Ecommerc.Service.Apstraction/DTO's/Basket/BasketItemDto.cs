using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
    }
}

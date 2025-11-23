using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket
{
    public class UpdataBaskeRequestDto
    {
        public string  BasketId { get; set; }
        public ICollection<BasketItemDto> Items { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class BasketException:ApplicationException
    {
        public int StutasCode { get; set; }
        public BasketException(string meassage , int code):base(meassage) 
        {
            StutasCode = code;
        }
    }
}

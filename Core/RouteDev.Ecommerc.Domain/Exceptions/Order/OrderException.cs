using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Order
{
    public class OrderException:ApplicationException
    {
        public  int Code { get; set; }
        public OrderException(string message , int code):base(message)
        {
            
            Code = code;
        }
    }
}

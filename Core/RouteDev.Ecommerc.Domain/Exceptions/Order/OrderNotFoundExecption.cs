using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Order
{
    public class OrderNotFoundExecption:OrderException
    {
        public OrderNotFoundExecption(string orderId):base($"Order with id:{orderId} was not found.",404)
        {

        }
    }
}

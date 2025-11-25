using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Order
{
    public class OrdersNotFoundExecption:OrderException
    {
        public OrdersNotFoundExecption(string email):base($"Orders with email:{email} were not found.",404)
        {
        }
  
    }
}

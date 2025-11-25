using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Order
{
    public class DeliveryMethodNotFoundException:OrderException
    {
        public DeliveryMethodNotFoundException(int id):base($"Delivery method with id:{id} was not found.",404)
        {
        }
    }
}

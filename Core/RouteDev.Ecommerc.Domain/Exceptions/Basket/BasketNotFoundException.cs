using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class BasketNotFoundException:BasketException
    {
        public BasketNotFoundException(string id ):base($"the Basket with id :{id} Not Found",404)
        {
            
        }
    }
}

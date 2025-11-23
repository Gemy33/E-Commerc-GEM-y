using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class BasketLimitExceededException:BasketException
    {
        public BasketLimitExceededException(string id):base($"Basket with id:{id} has exceeded the item limit", 400)
        {
            
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class UnauthorizedBasketAccessException:BasketException
    {
        public UnauthorizedBasketAccessException():base("You don't have permission to access this basket",401)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class BasketNotFoundException:BasketException
    {
        public BasketNotFoundException():base("This Basket Not Found",404)
        {
            
        }
    }
}

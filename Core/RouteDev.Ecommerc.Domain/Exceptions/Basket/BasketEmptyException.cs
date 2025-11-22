using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class BasketEmptyException:BasketException
    {
        public BasketEmptyException():base("Basket is Empty",400)
        {
            
        }
    }
}

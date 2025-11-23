using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.Basket
{
    public class BasketUpdateException:BasketException
    {
        public BasketUpdateException():base("Failed to update the basket", 500)
        {
            
        }
    }
}

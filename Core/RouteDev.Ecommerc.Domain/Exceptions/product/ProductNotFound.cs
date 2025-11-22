using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.NotFound
{
    public class ProductNotFound: ProductException
    {
        public ProductNotFound(int id):base($"Product with id :{id} Not Found",404)
        {
            
        }
    }

}

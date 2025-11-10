using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.NotFound
{
    public class ProductNotFound(int id): NotFoundException($"The product with Id : {id} Not found")
    {
    }
}

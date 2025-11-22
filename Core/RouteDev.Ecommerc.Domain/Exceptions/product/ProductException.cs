using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.NotFound
{
    public class ProductException: Exception
    {
        public int StatusCode { get; set; }
        public ProductException(string message ,  int statusCode):base(message)
        {
            StatusCode = statusCode;
        }
    }
}

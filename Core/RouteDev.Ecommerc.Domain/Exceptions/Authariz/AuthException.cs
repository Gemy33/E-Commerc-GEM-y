using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class AuthException: ApplicationException
    {
        public int statusCode;

        public AuthException(int statusCode, string massage):base(massage)
        {
            this.statusCode = statusCode;
        }
    }
}

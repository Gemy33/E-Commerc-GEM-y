using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class AddressNotFoundException : AuthException
    {
        public AddressNotFoundException() : base(404,"User does not have an address")
        {
        }
    }
}

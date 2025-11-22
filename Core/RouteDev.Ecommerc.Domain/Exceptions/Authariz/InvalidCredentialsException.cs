using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class InvalidCredentialsException:AuthException
    {
        public InvalidCredentialsException():base(401, "Invalid Email or Password")
        {
            
        }
    }
}

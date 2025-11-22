using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class TokenGenerationException:AuthException
    {
        public TokenGenerationException():base(500,"Failed to generate authentication token")
        {
            
        }
    }

}

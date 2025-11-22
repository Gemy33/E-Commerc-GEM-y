using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class UserLockedOutException:AuthException
    {
        public UserLockedOutException():base(423,"User account is locked out")
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class UserNotFoundException:AuthException
    {
        public UserNotFoundException(string email):base(404, $"User with email '{email}' not found")
        {
            
        }
    }
}

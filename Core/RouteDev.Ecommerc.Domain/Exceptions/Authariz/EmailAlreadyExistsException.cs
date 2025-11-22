using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions.UnAuthariz
{
    public class EmailAlreadyExistsException:AuthException
    {
        public EmailAlreadyExistsException(string email):base(409,$"Email '{email}' is already registered")
        {
            
        }
    }
}

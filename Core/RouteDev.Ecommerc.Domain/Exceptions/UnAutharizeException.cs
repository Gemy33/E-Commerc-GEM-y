using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Exceptions
{
    public class UnAutharizeException:ApplicationException
    {
        public UnAutharizeException(string massage = "Invalid Login"):base(massage)
        {
            
        }
    }
}

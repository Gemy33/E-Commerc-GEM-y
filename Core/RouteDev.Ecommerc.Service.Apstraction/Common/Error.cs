using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Common
{
    public class Error
    {
        public string Feild { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}

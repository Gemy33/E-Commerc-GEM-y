using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Common
{
    public class ValidatioinErrors
    {
        public int stata { get; set; } = 400;
        public IEnumerable<Error> Errors { get; set; }
        public string Massage { get; set; } = "One or more validation errors occurred.";
    }
}

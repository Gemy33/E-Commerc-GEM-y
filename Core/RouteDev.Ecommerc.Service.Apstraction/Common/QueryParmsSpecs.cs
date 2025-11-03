using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Common
{
    public class QueryParmsSpecs
    {
        //string? sort, int? brandId,int? typeId,string? Search
        public string? sort { get; set; }
        public int?  brandId { get; set; }
        public int? typeId { get; set; }
        public string? Search { get; set; }
    }
}

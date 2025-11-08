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
        int  _maxPageSize = 10;

        public string? sort { get; set; }
        public int? brandId { get; set; }
        public int? typeId { get; set; }
        public string? Search { get; set; }

        private int _pageSize = 5;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if(value < 1)
                    _pageSize = 1;
                else if(value > _maxPageSize)
                    _pageSize = _maxPageSize;
                else
                    _pageSize = value;

            }
        }
        private int _pageIndex = 1;
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = (value < 1) ? 1 : value; }
        }

    }
}

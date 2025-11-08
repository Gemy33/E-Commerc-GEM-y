using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Specifications
{
    public class CountProdutcSpecification : BaseSpecification<Product>
    {
        public CountProdutcSpecification(QueryParmsSpecs parmsSpecs)
        {
            AddFilter(p =>
                     (!parmsSpecs.brandId.HasValue || p.BrandId == parmsSpecs.brandId)
                     &&
                     (!parmsSpecs.typeId.HasValue || p.TypeId == parmsSpecs.typeId)
                     );
        }
    }
}

using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Products
{
    public class ProductBrand : BaseAuditable<int>
    {
        public required string Name { get; set; }
    }
}

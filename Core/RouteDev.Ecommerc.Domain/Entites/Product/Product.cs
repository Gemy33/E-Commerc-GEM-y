using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Entites.Products
{
    public class Product : BaseAuditable<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required string PictureUrl { get; set; }

        public int? TypeId { get; set; }
        public  ProductType? Type { get; set; }
        public int? BrandId { get; set; }
        public  ProductBrand? Brand { get; set; }
    }
}

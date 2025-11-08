using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.DTO_s.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required string PictureUrl { get; set; }
        public int? TypeId { get; set; }
        public string? Type { get; set; }
        public int? BrandId { get; set; }
        public string? Brand { get; set; }
    }

}

using RouteDev.Ecommerc.Domain.Entites.Base;

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

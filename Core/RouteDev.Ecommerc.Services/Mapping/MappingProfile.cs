using AutoMapper;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Product;

namespace RouteDev.Ecommerc.Services.Mapping
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(p => p.Brand, src => src.MapFrom(s => s.Brand!.Name))
            .ForMember(p => p.Type, src => src.MapFrom(s => s.Type!.Name))
            .ForMember(p => p.PictureUrl, src => src.MapFrom<ProductUrlResolver>());

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        }
    }
}

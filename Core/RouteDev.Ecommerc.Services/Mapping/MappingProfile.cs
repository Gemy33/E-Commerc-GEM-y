using AutoMapper;
using RouteDev.Ecommerc.Domain.Entites.Baskets;
using RouteDev.Ecommerc.Domain.Entites.Orders;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Auth;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Basket;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Order;
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
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(D => D.ProductId , opt => opt.MapFrom(S => S.Product.ProductId))
                .ForMember(D => D.PictureUrl, opt => opt.MapFrom(S => S.Product.PictureUrl))
                .ForMember(D => D.ProductName, opt => opt.MapFrom(S => S.Product.ProductName))
                ;
            CreateMap<OrderAddress, AddressDto>();
            CreateMap<DeliveryMethod, DeliveryMethodDTo>();
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.DeliveryMethod, option => option.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(D => D.deliveryCost, opt => opt.MapFrom(S => S.DeliveryMethod.Cost));
                

        
            

        }
    }
}

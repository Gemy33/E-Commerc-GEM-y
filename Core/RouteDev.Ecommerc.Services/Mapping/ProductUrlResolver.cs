using AutoMapper;
using Microsoft.Extensions.Configuration;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services.Mapping
{
    public class ProductUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration configuration = configuration;

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{configuration["URLS:EcommerceApi"]}/{source.PictureUrl}";
            }
            return "";

        }
    }
}

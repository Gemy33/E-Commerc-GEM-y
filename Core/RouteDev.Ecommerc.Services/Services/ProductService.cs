using AutoMapper;
using RouteDev.Ecommerc.Domain.Contracts;
using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Domain.Specifications;
using RouteDev.Ecommerc.Domain.Specifications.productSpecification;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Product;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services.Services
{
    internal class ProductService : IproductService
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uniteOfWork,IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<BrandDto>> GetAlLBrandAsync()
        {
            var brands = await _uniteOfWork.GetGenericRepoAsync<ProductBrand , int>().GetAllAsync();
            var BrnadSDeto = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return BrnadSDeto;
        }

       

        public async Task<IEnumerable<ProductDto>> GetAlLProductAsync(QueryParmsSpecs parmsSpecs)
        {
            var specs = new ProductSpecification(parmsSpecs);

            var products = await _uniteOfWork.GetGenericRepoAsync<Product, int>().GetAllWithSpecsAsync(specs);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDto;
        }

        public async Task<IEnumerable<TypeDto>> GetAlLTypeAsync()
        {
            var types = await _uniteOfWork.GetGenericRepoAsync<ProductType, int>().GetAllAsync();
            var TypesDto = _mapper.Map<IEnumerable<TypeDto>>(types);
            return TypesDto;
        }

    
        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var specs = new ProductSpecification(id);
            var product = await _uniteOfWork.GetGenericRepoAsync<Product, int>().GetByIdWithSpecsAsync(specs);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}

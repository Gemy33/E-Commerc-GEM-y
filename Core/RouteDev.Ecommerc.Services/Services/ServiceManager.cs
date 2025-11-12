using AutoMapper;
using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Services.Services
{
    public class ServiceManager : IserviceManager
    {
        readonly Lazy<IproductService> _productService;
        readonly Lazy<IBasketService> _basketService;
        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper , IBasket basket)
        {
            _productService = new Lazy<IproductService>(() => new ProductService(unitOfWork,mapper));
            _basketService = new Lazy<IBasketService>(() => new BasketService(basket, mapper));
        }
        public IproductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;
    }
}

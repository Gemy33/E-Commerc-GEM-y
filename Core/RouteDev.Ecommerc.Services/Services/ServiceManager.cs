using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Domain.Contracts.RedisRepos;
using RouteDev.Ecommerc.Domain.Entites.IDentity;
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
        readonly Lazy<IAuthService> _authService;
        readonly Lazy<IOrderService> _orderService;
        //readonly Lazy<ICachService> cachService;



        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper ,ICachRepo cachRepo, IBasket basket,UserManager<ApplicationUser> userManager, IConfiguration _configuration, 
            SignInManager<ApplicationUser> signInManager ,ILogger<AuthService> logger, ILogger<BasketService> loggerS)
        {
            _productService = new Lazy<IproductService>(() => new ProductService(unitOfWork,mapper));
            _basketService = new Lazy<IBasketService>(() => new BasketService(basket, mapper, loggerS));
            _authService = new Lazy<IAuthService>(() => new AuthService(_configuration, userManager, signInManager, logger));
            _orderService = new Lazy<IOrderService>(() => new OrderService(unitOfWork, basket, mapper));
            //cachService = new Lazy<ICachService>(() => new CachService(cachRepo));



        }
        public IproductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;

        public IAuthService AuthService => _authService.Value;

        public IOrderService OrderService => _orderService.Value;

        //public ICachService CachService => cachService.Value;
    }
}

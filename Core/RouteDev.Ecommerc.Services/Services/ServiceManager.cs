using AutoMapper;
using RouteDev.Ecommerc.Domain.Contracts;
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
        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _productService = new Lazy<IproductService>(() => new ProductService(unitOfWork,mapper));
        }
        public IproductService ProductService => _productService.Value;
    }
}

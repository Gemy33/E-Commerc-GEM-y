using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Services
{
    public interface IserviceManager
    {
        IproductService ProductService { get; }
        IBasketService BasketService { get; }
    }
}

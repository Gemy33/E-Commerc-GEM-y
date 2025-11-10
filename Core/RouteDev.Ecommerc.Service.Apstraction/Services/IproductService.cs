using RouteDev.Ecommerc.Service.Apstraction.Common;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Service.Apstraction.Services
{
    public interface IproductService
    {
        Task<PaginatedResult<ProductDto>>GetAlLProductAsync(QueryParmsSpecs parmsSpecs);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<BrandDto>> GetAlLBrandAsync();

        Task<IEnumerable<TypeDto>> GetAlLTypeAsync();
        public  Task<int> CountAsync(QueryParmsSpecs parmsSpecs);



    }
}

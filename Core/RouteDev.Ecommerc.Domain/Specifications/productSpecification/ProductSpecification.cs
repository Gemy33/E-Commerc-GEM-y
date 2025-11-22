using RouteDev.Ecommerc.Domain.Entites.Products;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Specifications.productSpecification
{
    public class ProductSpecification : BaseSpecification<Product,int>
    {
        public ProductSpecification(QueryParmsSpecs parmsSpecs) : base()
        {

            Includes.Add(p => p.Type);
            Includes.Add(p => p.Brand);
            AddSort(parmsSpecs.sort);
            AddFilter(
                p =>
            (!parmsSpecs.brandId.HasValue || p.BrandId == parmsSpecs.brandId)
            &&
            (!parmsSpecs.typeId.HasValue || p.TypeId == parmsSpecs.typeId)
            );
            if (!string.IsNullOrEmpty(parmsSpecs.Search))
            {
                var lowerCaseSearch = parmsSpecs.Search.ToLower();
                AddSearch(p => p.Name.ToLower().Contains(lowerCaseSearch));
            }
            ApplyPagination((parmsSpecs.PageIndex - 1) * parmsSpecs.PageSize, parmsSpecs.PageSize);

        }
        public ProductSpecification(int id) : base(id)
        {
            Includes.Add(p => p.Type);
            Includes.Add(p => p.Brand);
        }

        
        public override void AddSort(string sortOption)
        {
            if (string.IsNullOrEmpty(sortOption)) return;
            switch (sortOption)
            {
                case "price":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }


        }
    }
}

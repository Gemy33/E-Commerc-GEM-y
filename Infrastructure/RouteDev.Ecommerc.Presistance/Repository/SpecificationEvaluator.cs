using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Contracts;

using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presistance.Repository
{
    public static class SpecificationEvaluator<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> BaseQuery, IBaseSpecifications<TEntity> spec)
        {
            var query = BaseQuery;
            if( spec.Criatily != null)
            {
                query = query.Where(spec.Criatily);
            }
            if (spec.filter != null)
            {
                query = query.Where(spec.filter);
            }

            if (spec.Search is not null)
            {
                query = query.Where(spec.Search);
            }
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Contracts
{
    public interface IBaseSpecifications<TEntity>
    {
        public Expression<Func<TEntity,bool>> filter { get; set; }
        public Expression<Func<TEntity, bool>> Criatily{ get; set; }

        public List<Expression<Func<TEntity,object>>> Includes { get; set; }

        Expression<Func<TEntity, bool>> Search { get; }

        Expression<Func<TEntity,object>> OrderBy { get; }
        Expression<Func<TEntity,object>> OrderByDescending { get; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; }



    }
}

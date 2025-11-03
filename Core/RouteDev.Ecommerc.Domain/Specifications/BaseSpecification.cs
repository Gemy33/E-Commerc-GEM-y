using RouteDev.Ecommerc.Domain.Contracts;
using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Specifications
{
    public class BaseSpecification<TEntity> : IBaseSpecifications<TEntity>
        where TEntity : BaseEntity<int>
    {
        public Expression<Func<TEntity, bool>> filter { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get ; set ; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, bool>> Search { get; private set; } = null;

        public Expression<Func<TEntity, object>> OrderBy { get; private set; } = null;

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; } = null;
        public Expression<Func<TEntity, bool>> Criatily { get; set; }

        public BaseSpecification()
        {

        }
        public BaseSpecification(int id)
        {
            Criatily = e => e.Id.Equals(id);

        }


        private protected virtual void AddSearch(Expression<Func<TEntity, bool>> SearchExpression)
        {
            Search = SearchExpression; // p => p.Name.ToLower().Contains(lowerCaseSearch);
        }

        private protected virtual void AddFilter(Expression<Func<TEntity, bool>> SearchExpression)
        {
            filter = SearchExpression;
        }
        public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        public void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        public void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
        public virtual void AddSort(string sortOption)
        {

        }
    }
}

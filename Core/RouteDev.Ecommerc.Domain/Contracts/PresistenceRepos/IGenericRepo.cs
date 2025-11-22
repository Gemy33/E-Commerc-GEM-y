using RouteDev.Ecommerc.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos
{
    public interface IGenericRepo<TEntity,Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public  Task<TEntity?> GetByIdAsyncWithSpecs(Tkey id, IBaseSpecifications<TEntity> specs);
        public Task<int> CountAsync(IBaseSpecifications<TEntity> specs);
        Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = false);
        public  Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(IBaseSpecifications<TEntity> specs, bool withTracking = false);
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task<TEntity?> GetByIdWithSpecsAsync(IBaseSpecifications<TEntity> specs);

        void Add(TEntity entity);   
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

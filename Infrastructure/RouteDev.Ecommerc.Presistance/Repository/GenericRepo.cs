using Microsoft.EntityFrameworkCore;
using RouteDev.Ecommerc.Domain.Contracts;
using RouteDev.Ecommerc.Domain.Entites.Base;
using RouteDev.Ecommerc.Presistance.Data.Context;

namespace RouteDev.Ecommerc.Presistance.Repository
{
    internal class GenericRepo<TEntity, Tkey>(AppDbContext _context) : IGenericRepo<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool WithTracking = false) => WithTracking ? await _context.Set<TEntity>().ToListAsync() : await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(IBaseSpecifications<TEntity> specs,bool withTracking = false)
        {
            //var query = SpecificationEvaluator<TEntity, Tkey>.GetQuery(_context.Set<TEntity>(), specs);
           var query =  ApplySpecifications(specs);
            if (withTracking)
            {
                return await query.ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }
    
        


        private IQueryable<TEntity> ApplySpecifications(IBaseSpecifications<TEntity> specs)
        {
            return SpecificationEvaluator<TEntity, Tkey>.GetQuery(_context.Set<TEntity>(), specs);
        }
        public Task<TEntity?> GetByIdAsync(Tkey id) => _context.Set<TEntity>().FindAsync(id).AsTask();

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);


        public void Delete(TEntity entity) => _context.Set<TEntity>().Update(entity);




        public void Update(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public Task<TEntity?> GetByIdWithSpecsAsync(IBaseSpecifications<TEntity> specs)
        {
            var query = ApplySpecifications(specs);
            return query.FirstOrDefaultAsync();
        }
    }
}

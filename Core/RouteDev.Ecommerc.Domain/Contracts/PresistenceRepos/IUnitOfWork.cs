using RouteDev.Ecommerc.Domain.Entites.Base;

namespace RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos
{
    public interface IUnitOfWork : IDisposable
    {
        #region sign for pro 
        //public IGenericRepo<Product, int> ProductRepository { get;  }
        //public IGenericRepo<ProductBrand, int> BrandRepository { get; }

        //public IGenericRepo<ProductType, int> TypeRepository { get; } 
        #endregion

        IGenericRepo<TEntity,Tkey>GetGenericRepoAsync<TEntity, Tkey>()
            where TEntity : BaseEntity<Tkey>
            where Tkey : IEquatable<Tkey>;

        Task<int> CompleteAsync();
    }
}

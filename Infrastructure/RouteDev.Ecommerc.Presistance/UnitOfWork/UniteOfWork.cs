using RouteDev.Ecommerc.Domain.Contracts.PresistenceRepos;
using RouteDev.Ecommerc.Domain.Entites.Base;
using RouteDev.Ecommerc.Presistance.Data;
using RouteDev.Ecommerc.Presistance.Repository;
using System.Collections.Concurrent;

namespace RouteDev.Ecommerc.Presistance.UnitOfWork
{

    #region UniteOfWord (Lazy)
    //public class UniteofWork : IUnitOfWork
    //{
    //    private readonly Lazy<IGenericRepo<Product, int>> _productRepository;
    //    private readonly Lazy<IGenericRepo<ProductBrand, int>> _brandRepository;
    //    private readonly Lazy<IGenericRepo<ProductType, int>> _typeRepository;
    //    private readonly AppDbContext _context;

    //    public UniteofWork(AppDbContext context)
    //    {
    //        _productRepository = new Lazy<IGenericRepo<Product, int>>(() => new Repository.GenericRepo<Product, int>(_context));
    //        _brandRepository = new Lazy<IGenericRepo<ProductBrand, int>>(() => new Repository.GenericRepo<ProductBrand, int>(_context));
    //        _typeRepository = new Lazy<IGenericRepo<ProductType, int>>(() => new Repository.GenericRepo<ProductType, int>(_context));
    //        _context = context;
    //    }
    //    public IGenericRepo<Product, int> ProductRepository => _productRepository.Value;
    //    public IGenericRepo<ProductBrand, int> BrandRepository => _brandRepository.Value;
    //    public IGenericRepo<ProductType, int> TypeRepository => _typeRepository.Value;
    //    public Task<int> CompleteAsync()
    //    {
    //        return _context.SaveChangesAsync();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }


    //} 
    #endregion
    public class UniteOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        /// readonly Dictionary<string, object> Repos;
        readonly ConcurrentDictionary<string, object> _Repo;
        public UniteOfWork(StoreDbContext context)
        {
            _context = context;
            /// Repos = new Dictionary<string, object>();
            _Repo = new ConcurrentDictionary<string, object>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepo<TEntity, Tkey> GetGenericRepoAsync<TEntity, Tkey>()
            where TEntity : BaseEntity<Tkey>
            where Tkey : IEquatable<Tkey>
        {
            //var RepoName = typeof(IGenericRepo<TEntity, Tkey>).FullName;
            var name= typeof(TEntity).Name;
            var repo = _Repo.GetOrAdd(name, new GenericRepo<TEntity, Tkey>(_context));
            return (IGenericRepo<TEntity, Tkey>)repo;


            #region Dictionary<string,objec>
            //if (Repos.ContainsKey(RepoName))
            //    return (IGenericRepo<TEntity, Tkey>)Repos[RepoName];
            //var repo = new GenericRepo<TEntity, Tkey>(_context);
            //Repos.Add(RepoName, repo);
            //return repo; 
            #endregion

        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

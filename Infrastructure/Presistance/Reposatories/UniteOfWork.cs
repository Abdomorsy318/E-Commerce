
namespace Presistance.Reposatories
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private ConcurrentDictionary<string, object> _repositories;

        public UniteOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public IGenaricReposatory<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            //var key = typeof(TEntity).Name;
            //if (_repositories.ContainsKey(key))
            //    return _repositories[key] as IGenaricReposatory<TEntity, Tkey>;
            //else
            //{
            //    var repository = new GenaricReposatory<TEntity, Tkey>(_dbContext);
            //    _repositories.Add(key, repository);
            //    return repository;
            //}
            //return new GenaricReposatory<TEntity, Tkey>(_dbContext);
            return (IGenaricReposatory<TEntity , Tkey>) _repositories.GetOrAdd(typeof(TEntity).Name, (_) => new GenaricReposatory<TEntity , Tkey>(_dbContext));
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}

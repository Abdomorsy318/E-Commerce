using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Presistance.Data;

namespace Presistance.Reposatories
{
    public class GenaricReposatory<TEntity, Tkey> : IGenaricReposatory<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly ApplicationDbContext _dbContext;

        public GenaricReposatory(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);
        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking) => asNoTracking ?
                                                                                  await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync() 
                                                                                : await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
    }
}

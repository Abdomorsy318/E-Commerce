using Domain.Entities;

namespace Domain.Contracts
{
    public interface IGenaricReposatory<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        #region For Specification
        Task<IEnumerable<TEntity>> GetAllWithSpecificationsAsync(Specifications<TEntity> specifications);
        Task<TEntity?> GetByIdWithSpecificationsAsync(Specifications<TEntity> specifications);
        
        #endregion
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        //Task GetAllAsync();
    }
}

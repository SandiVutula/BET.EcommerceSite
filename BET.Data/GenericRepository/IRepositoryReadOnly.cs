using System.Linq.Expressions;

namespace BET.Data.GenericRepository
{
    public interface IRepositoryReadOnly
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
            where TEntity : class;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null,
        int? skip = null,
        int? take = null)
            where TEntity : class;

        Task<TEntity> GetOneAsync<TEntity>(
          Expression<Func<TEntity, bool>> filter = null,
          string includeProperties = null)
          where TEntity : class;

        Task<TEntity> GetFirstAsync<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null)
            where TEntity : class;

        TEntity GetById<TEntity>(object id)
            where TEntity : class;

        Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class;
    }
}

using Microsoft.EntityFrameworkCore;

namespace BET.Data.GenericRepository
{
    public interface IRepository : IRepositoryReadOnly
    {
        void Create<TEntity>(TEntity entity)
             where TEntity : class;
        void Update<TEntity>(TEntity entity, string? modifiedBy = null)
            where TEntity : class;

        void Remove<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class;

        void Save();

        Task SaveAsync();
    }
}

using BET.Data.EcommerceDbContext;
using Microsoft.EntityFrameworkCore;

namespace BET.Data.GenericRepository.Implementation
{
    public class EntityFrameworkRepository : EntityFrameworkRepositoryReadOnly, IRepository
    {
        private readonly EntiyFrameworkDbContext _context;
        public EntityFrameworkRepository(EntiyFrameworkDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual void Create<TEntity>(TEntity entity)
         where TEntity : class
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class
        {
            if (_context.ChangeTracker.HasChanges())
                _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual  void Remove<TEntity>(TEntity entity, string modifiedBy = null)
        where TEntity : class
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                ThrowEnhancedValidationException(e);
            }

            return Task.FromResult(0);
        }

        protected virtual void ThrowEnhancedValidationException(DbUpdateException e)
        {
            throw new DbUpdateException(e.Message, e.InnerException);
        }
    }
}
 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Common.Repository
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;
        protected readonly IDictionary<Type, object> _repositories = new Dictionary<Type, object>();

        protected UnitOfWork(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            _dbContext = dbContext;
        }

        protected void RegisterCustomRepository<TEntity>(Func<IRepository<TEntity>> fncRepository) where TEntity : class
        {
            Type entityType = typeof(TEntity);
            if (_repositories.ContainsKey(entityType))
                throw new Exception($"Repository has already been registered for the the entity type: {entityType.Name}");

            _repositories.Add(entityType, new Lazy<IRepository<TEntity>>(fncRepository));
        }

        #region Dispose
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
        #endregion

        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            Type entityType = typeof(TEntity);

            object repository;
            if (_repositories.TryGetValue(entityType, out repository))
            {
                var lazyRep = repository as Lazy<IRepository<TEntity>>;
                return (lazyRep != null) ? lazyRep.Value : (IRepository<TEntity>)repository;
            }

            IRepository<TEntity> rep = CreateDefaultRepository<TEntity>();
            _repositories.Add(entityType, rep);
            return rep;
        }

        protected virtual IRepository<TEntity> CreateDefaultRepository<TEntity>() where TEntity : class
        {
            Type repositoryType = typeof(Repository<>);
            return (IRepository<TEntity>)Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);
        }

        public void Save()
        {
            foreach (DbEntityEntry dbEntityEntry in _dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Added))
            {
                var entityVersionable = dbEntityEntry.Entity as IEntityVersionable;
                if (entityVersionable != null)
                {
                    entityVersionable.Version = 1;
                    entityVersionable.CreatedDate = DateTime.Now;
                    entityVersionable.UpdatedDate = entityVersionable.CreatedDate;
                }
            }
            foreach (DbEntityEntry dbEntityEntry in _dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified))
            {
                var entityVersionable = dbEntityEntry.Entity as IEntityVersionable;
                if (entityVersionable != null)
                {
                    entityVersionable.Version++;
                    entityVersionable.UpdatedDate = DateTime.Now;
                }
            }

           _dbContext.SaveChanges();
        }

    }
}

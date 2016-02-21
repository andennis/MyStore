using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual TEntity Find(int key)
        {
            return _dbSet.Find(key);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
        }
        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public virtual IRepositoryQuery<TEntity> Query()
        {
            return new RepositoryQuery<TEntity>(this);
        }

        internal IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeProperties = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            includeProperties?.ForEach(i => query = query.Include(i));

            if (filter != null)
                query = query.Where(filter);

            query = (orderBy != null) ? orderBy(query) : query.OrderBy(x => true);

            if (page != null && pageSize != null)
            {
                query = query
                    .Skip(page.Value)
                    .Take(pageSize.Value);
                //query = query
                //    .Skip((page.Value - 1)*pageSize.Value)
                //    .Take(pageSize.Value);
            }
            return query;
        }

    }
}

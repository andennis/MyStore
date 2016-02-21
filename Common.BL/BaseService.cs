using System.Collections.Generic;
using System.Linq;
using Common.Repository;

namespace Common.BL
{
    public abstract class BaseService<TEntity, TSearchFilter, TUnitOfWork> : IBaseService<TEntity, TSearchFilter>
        where TEntity : class, new()
        where TSearchFilter : DefaultSearchFilter
        where TUnitOfWork : IUnitOfWork
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly TUnitOfWork _unitOfWork;

        protected BaseService(TUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            Validate(entity);
            _repository.Insert(entity);
            _unitOfWork.Save();
        }
        public virtual void Update(TEntity entity)
        {
            Validate(entity);
            _repository.Update(entity);
            _unitOfWork.Save();
        }
        public virtual void Delete(int entityId)
        {
            _repository.Delete(entityId);
            _unitOfWork.Save();
        }
        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Save();
        }

        public virtual TEntity Get(int entityId)
        {
            return _repository.Find(entityId);
        }

        public virtual IEnumerable<TEntity> Search(TSearchFilter searchFilter)
        {
            return _repository.Query().Get().ToList();
        }

        protected virtual void Validate(TEntity entity)
        {
        }

    }
}

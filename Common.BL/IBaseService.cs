using System.Collections.Generic;

namespace Common.BL
{
    public interface IBaseService<TEntity, TSearchFilter>
        where TEntity : class
        where TSearchFilter : DefaultSearchFilter
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int entityId);
        TEntity Get(int entityId);

        IEnumerable<TEntity> Search(TSearchFilter searchFilter);
    }
}
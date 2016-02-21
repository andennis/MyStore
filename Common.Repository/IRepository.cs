namespace Common.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);

        TEntity Find(int key);
        IRepositoryQuery<TEntity> Query();
    }

}

using Common.Repository;
using MyStore.Core;
using MyStore.Core.Repositories;

namespace MyStore.Repository
{
    public class MyStoreUnitOfWork : UnitOfWork, IMyStoreUnitOfWork
    {
        private IOrderRepository _orderRepository;

        public MyStoreUnitOfWork(IDbConfig dbConfig)
            : base(new MyStoreDbContext(dbConfig.ConnectionString))
        {
            //It's done to perevet default repository creation in the method GetRepository
            RegisterCustomRepository(() => OrderRepository);
        }

        public IOrderRepository OrderRepository =>
            _orderRepository ?? (_orderRepository = new OrderRepository(_dbContext));

    }
}

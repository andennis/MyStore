using Common.Repository;
using MyStore.Core.Repositories;

namespace MyStore.Core
{
    public interface IMyStoreUnitOfWork : IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
    }
}
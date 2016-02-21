using System.Data.Entity;
using Common.Repository;
using MyStore.Core.Entities;
using MyStore.Core.Repositories;

namespace MyStore.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

    }
}

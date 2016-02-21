using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;

namespace MyStore.BL.Services
{
    public class OrderService : BaseService<Order, OrderFilter, IMyStoreUnitOfWork>, IOrderService
    {
        public OrderService(IMyStoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;

namespace MyStore.BL.Services
{
    public class OrderItemService : BaseService<OrderItem, OrderItemFilter, IMyStoreUnitOfWork>, IOrderItemService
    {
        public OrderItemService(IMyStoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override OrderItem Get(int entityId)
        {
            return _repository.Query()
                .Filter(x => x.OrderItemId == entityId)
                .Include(x => x.Product)
                .Get().FirstOrDefault();
        }

        public override IEnumerable<OrderItem> Search(OrderItemFilter searchFilter)
        {
            return _repository.Query()
                .Filter(x => x.OrderId == searchFilter.OrderId)
                .Include(x => x.Product)
                .Get().ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.Enums;
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

        public override void Create(Order entity)
        {
            entity.Status = OrderStatus.Pending;
            base.Create(entity);
            entity.OrderRefNumber = $"RFN-{DateTime.Today.ToString("yyyyMMdd")}-{entity.OrderId}";
            Update(entity);
        }

        public override Order Get(int entityId)
        {
            return _repository.Query()
                .Filter(x => x.OrderId == entityId)
                .Include(x => x.Client)
                .Include(x => x.OrderItems)
                .Include(x => x.OrderItems.Select(oi => oi.Product))
                .Get().FirstOrDefault();
        }

        public override IEnumerable<Order> Search(OrderFilter searchFilter)
        {
            var query = _repository.Query()
                .Include(x => x.Client);
            if (searchFilter.ClientId.HasValue)
                query.Filter(x => x.ClientId == searchFilter.ClientId);

            return query.Get().ToList();
        }
    }
}

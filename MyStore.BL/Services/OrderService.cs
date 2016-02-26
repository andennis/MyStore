using System;
using System.Collections.Generic;
using System.Linq;
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

        public override void Create(Order entity)
        {
            base.Create(entity);
            entity.OrderRefNumber = $"RFN-{DateTime.Today.ToString("yyyyMMdd")}-{entity.ClientId}";
            Update(entity);
        }

        public override Order Get(int entityId)
        {
            return _repository.Query()
                .Filter(x => x.OrderId == entityId)
                .Include(x => x.Client)
                .Get().FirstOrDefault();
        }

        public override IEnumerable<Order> Search(OrderFilter searchFilter)
        {
            return _repository.Query()
                .Include(x => x.Client)
                .Get().ToList();
        }
    }
}

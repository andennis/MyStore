using System.Collections.Generic;
using System.Linq;
using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;

namespace MyStore.BL.Services
{
    public class BasketItemService : BaseService<BasketItem, BasketItemFilter, IMyStoreUnitOfWork>, IBasketItemService
    {
        public BasketItemService(IMyStoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override BasketItem Get(int entityId)
        {
            return _repository.Query()
                .Include(x => x.Product)
                .Filter(x => x.BasketItemId == entityId)
                .Get().FirstOrDefault();
        }

        public override IEnumerable<BasketItem> Search(BasketItemFilter searchFilter)
        {
            return _repository.Query()
                .Filter(x => x.ClientId == searchFilter.ClientId)
                .Include(x => x.Product)
                .Get().ToList();
        }
    }
}

using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.Services;

namespace MyStore.BL.Services
{
    public class ProductService : BaseService<Product, DefaultSearchFilter, IMyStoreUnitOfWork>, IProductService
    {
        public ProductService(IMyStoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

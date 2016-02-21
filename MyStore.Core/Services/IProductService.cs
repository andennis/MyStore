using Common.BL;
using MyStore.Core.Entities;

namespace MyStore.Core.Services
{
    public interface IProductService : IBaseService<Product, DefaultSearchFilter>
    {
    }
}
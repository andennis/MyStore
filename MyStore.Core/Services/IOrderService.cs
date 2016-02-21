using Common.BL;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;

namespace MyStore.Core.Services
{
    public interface IOrderService : IBaseService<Order, OrderFilter>
    {
    }
}
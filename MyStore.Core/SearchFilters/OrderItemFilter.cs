using Common.BL;

namespace MyStore.Core.SearchFilters
{
    public class OrderItemFilter : DefaultSearchFilter
    {
        public int? OrderId { get; set; }
    }
}

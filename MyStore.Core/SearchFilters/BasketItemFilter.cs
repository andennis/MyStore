using Common.BL;

namespace MyStore.Core.SearchFilters
{
    public class BasketItemFilter : DefaultSearchFilter
    {
        public int? ClientId { get; set; }
    }
}

using Common.BL;

namespace MyStore.Core.SearchFilters
{
    public class OrderFilter : DefaultSearchFilter
    {
        public int? ClientId { get; set; }
    }
}

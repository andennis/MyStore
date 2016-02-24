using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

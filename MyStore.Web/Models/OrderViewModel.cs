using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public int OrderId { get; set; }
        public string OrderRefNumber { get; set; }
        public string Comment { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
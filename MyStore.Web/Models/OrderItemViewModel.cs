using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class OrderItemViewModel : BaseViewModel
    {
        public override int EntityId => OrderItemId;

        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }

        public int Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Comment { get; set; }

    }
}
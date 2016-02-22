using Common.Repository;

namespace MyStore.Core.Entities
{
    public class OrderItem : EntityVersionable
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Amount { get; set; }
        public string Comment { get; set; }
    }
}

using Common.Repository;

namespace MyStore.Core.Entities
{
    public class BasketItem : EntityVersionable
    {
        public int BasketItemId { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}

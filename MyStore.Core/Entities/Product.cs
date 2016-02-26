using Common.Repository;

namespace MyStore.Core.Entities
{
    public class Product : EntityVersionable
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}

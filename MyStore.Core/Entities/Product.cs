using Common.Repository;

namespace MyStore.Core.Entities
{
    public class Product : EntityVersionable
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

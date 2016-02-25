using System.Data.Entity.ModelConfiguration;
using MyStore.Core.Entities;

namespace MyStore.Repository.Mapping
{
    public class BasketItemConfiguration : EntityTypeConfiguration<BasketItem>
    {
        public BasketItemConfiguration(string dbScheme)
        {
            ToTable("BasketItem", dbScheme);
            Property(x => x.Version).IsConcurrencyToken();
            HasRequired(x => x.Client).WithMany().HasForeignKey(x => x.ClientId);
            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }

    }
}

using System.Data.Entity.ModelConfiguration;
using MyStore.Core.Entities;

namespace MyStore.Repository.Mapping
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration(string dbScheme)
        {
            ToTable("Product", dbScheme);
            Property(x => x.Version).IsConcurrencyToken();
            Property(x => x.Name).IsRequired().HasMaxLength(64);
        }
        
    }
}

using System.Data.Entity.ModelConfiguration;
using MyStore.Core.Entities;

namespace MyStore.Repository.Mapping
{
    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration(string dbScheme)
        {
            ToTable("OrderItem", dbScheme);
            Property(x => x.Version).IsConcurrencyToken();
            HasRequired(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId);
            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
        }
    }
}

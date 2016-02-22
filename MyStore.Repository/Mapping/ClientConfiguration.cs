using System.Data.Entity.ModelConfiguration;
using MyStore.Core.Entities;

namespace MyStore.Repository.Mapping
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration(string dbScheme)
        {
            ToTable("Client", dbScheme);
            Property(x => x.Version).IsConcurrencyToken();
            Property(x => x.Email).IsRequired().HasMaxLength(256);
            Property(x => x.LastName).IsRequired().HasMaxLength(64);
            Property(x => x.FirstName).HasMaxLength(64);
            HasOptional(x => x.User).WithMany().HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);
        }
    }
}

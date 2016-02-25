using System.Data.Entity.ModelConfiguration;
using MyStore.Core.Entities;

namespace MyStore.Repository.Mapping
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string dbScheme)
        {
            ToTable("User", dbScheme);
            Property(x => x.Version).IsConcurrencyToken();
            Property(x => x.UserName).IsRequired().HasMaxLength(64);
            Property(x => x.Password).HasMaxLength(512);
        }

    }
}

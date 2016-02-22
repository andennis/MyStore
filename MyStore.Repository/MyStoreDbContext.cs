using System.Data.Entity;
using MyStore.Repository.Mapping;

namespace MyStore.Repository
{
    public class MyStoreDbContext : DbContext
    {
        private const string DbScheme = "myst";

        public MyStoreDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration(DbScheme));
            modelBuilder.Configurations.Add(new OrderConfiguration(DbScheme));
            modelBuilder.Configurations.Add(new ClientConfiguration(DbScheme));
            modelBuilder.Configurations.Add(new OrderItemConfiguration(DbScheme));
            modelBuilder.Configurations.Add(new BasketItemConfiguration(DbScheme));

            base.OnModelCreating(modelBuilder);
        }
    }
}

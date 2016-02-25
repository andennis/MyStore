using System.Data.Entity;
using MyStore.Core.Entities;
using MyStore.Repository.Mapping;

namespace MyStore.Repository
{
    public class MyStoreDbContext : DbContext
    {
        private const string DbScheme = "myst";

        static MyStoreDbContext()
        {
            // Fixed "Provider not loaded" error            
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public MyStoreDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Product>(new ProductConfiguration(DbScheme));
            modelBuilder.Configurations.Add<Order>(new OrderConfiguration(DbScheme));
            modelBuilder.Configurations.Add<Client>(new ClientConfiguration(DbScheme));
            modelBuilder.Configurations.Add<OrderItem>(new OrderItemConfiguration(DbScheme));
            modelBuilder.Configurations.Add<BasketItem>(new BasketItemConfiguration(DbScheme));
            modelBuilder.Configurations.Add<User>(new UserConfiguration(DbScheme));

            base.OnModelCreating(modelBuilder);
        }
    }
}

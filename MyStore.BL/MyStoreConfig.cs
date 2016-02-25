using System.Configuration;
using MyStore.Core;
using MyStore.Core.Exceptions;

namespace MyStore.BL
{
    public class MyStoreConfig : IMyStoreConfig
    {
        public string ConnectionString
        {
            get
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["MyStoreConnection"];
                if (settings == null)
                    throw new MyStoreGeneralException("Connection string is not specified");

                return ConfigurationManager.ConnectionStrings["MyStoreConnection"].Name;
            }
        }
    }
}

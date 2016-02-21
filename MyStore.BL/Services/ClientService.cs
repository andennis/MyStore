using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.Services;

namespace MyStore.BL.Services
{
    public class ClientService : BaseService<Client, DefaultSearchFilter, IMyStoreUnitOfWork>, IClientService
    {
        public ClientService(IMyStoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

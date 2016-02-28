using System.Linq;
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

        public Client GetByUser(int userId)
        {
            return _repository.Query().Filter(x => x.UserId == userId).Get().FirstOrDefault();
        }

        public override void Create(Client entity)
        {
            if (entity.User != null)
                _unitOfWork.GetRepository<User>().Insert(entity.User);
            base.Create(entity);
        }
    }
}

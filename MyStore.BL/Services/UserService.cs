using System.Linq;
using Common.BL;
using MyStore.Core;
using MyStore.Core.Entities;
using MyStore.Core.Services;

namespace MyStore.BL.Services
{
    public class UserService : BaseService<User, DefaultSearchFilter, IMyStoreUnitOfWork>, IUserService
    {
        public UserService(IMyStoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public bool IsAuthenticated(string userName, string password)
        {
            User user = _repository.Query().Filter(x => x.UserName == userName).Get().FirstOrDefault();
            if (user == null)
                return false;

            return (user.Password == password);
        }

        public User Get(string userName)
        {
            return _repository.Query().Filter(x => x.UserName == userName).Get().FirstOrDefault();
        }
    }
}

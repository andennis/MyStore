using Common.BL;
using MyStore.Core.Entities;

namespace MyStore.Core.Services
{
    public interface IUserService : IBaseService<User, DefaultSearchFilter>
    {
        bool IsAuthenticated(string userName, string password);
        User Get(string userName);
    }
}
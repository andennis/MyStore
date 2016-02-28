using Common.BL;
using MyStore.Core.Entities;

namespace MyStore.Core.Services
{
    public interface IClientService : IBaseService<Client, DefaultSearchFilter>
    {
        Client GetByUser(int userId);
    }
}
using Common.BL;
using MyStore.Core.Entities;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class ClientController : BaseEntityController<ClientViewModel, Client, IClientService, DefaultSearchFilter>
    {
        public ClientController(IClientService clientService)
            :base(clientService)
        {
        }

    }
}
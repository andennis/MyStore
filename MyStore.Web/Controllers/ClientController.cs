using System.Web.Mvc;
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

        protected override void DoCreate(ClientViewModel model)
        {
            Client entity = Mapper.Map<ClientViewModel, Client>(model);
            entity.UserId = -1;
            entity.User = new User() {UserId = -1, UserName = model.UserName, Password = model.Password};
            _service.Create(entity);
        }
    }
}
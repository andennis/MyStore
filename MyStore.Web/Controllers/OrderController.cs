using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Common.BL;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class OrderController : BaseEntityController<OrderViewModel, Order, IOrderService, OrderFilter>
    {
        private readonly IClientService _clientService;

        public OrderController(IOrderService orderService, IClientService clientService)
            :base(orderService)
        {
            _clientService = clientService;
        }

        protected override void PrepareModelToCreateView(OrderViewModel model)
        {
            base.PrepareModelToCreateView(model);

            IEnumerable<Client> clients = _clientService.Search(new DefaultSearchFilter());
            model.Clients = new SelectList(clients.Select(c => new { Value = c.ClientId, Text = c.FirstName + " " + c.LastName}), "Value", "Text");
        }
    }
}
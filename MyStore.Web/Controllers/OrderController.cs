using System.Web.Mvc;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class OrderController : BaseEntityController<OrderViewModel, Order, IOrderService, OrderFilter>
    {
        public OrderController(IOrderService orderService)
            :base(orderService)
        {
        }

        public override ActionResult Index()
        {
            return View();
        }
    }
}
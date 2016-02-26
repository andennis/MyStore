using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class OrderItemController : BaseEntityController<OrderItemViewModel, OrderItem, IOrderItemService, OrderItemFilter>
    {
        public OrderItemController(IOrderItemService orderItemService)
            :base(orderItemService)
        {
        }

        protected override void SetDefaultReturnUrl(OrderItemViewModel model)
        {
            model.RedirectUrl = Url.Action("Edit", "Order", new {id = model.OrderId});
        }
    }
}
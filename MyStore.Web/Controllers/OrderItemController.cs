using System.Collections.Generic;
using System.Web.Mvc;
using Common.BL;
using MyStore.Core.Entities;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;
using System.Linq;
using Common.Web.Grid;

namespace MyStore.Web.Controllers
{
    public class OrderItemController : BaseEntityController<OrderItemViewModel, OrderItem, IOrderItemService, OrderItemFilter>
    {
        private readonly IProductService _productService;

        public OrderItemController(IOrderItemService orderItemService, IProductService productService)
            :base(orderItemService)
        {
            _productService = productService;
        }

        public ActionResult CreateOrderItem(int orderId)
        {
            return Create(m => m.OrderId = orderId);
        }

        [ActionName("CreateOrderItem")]
        public override ActionResult Create(OrderItemViewModel model)
        {
            return base.Create(model);
        }

        public override ActionResult GridSearch(GridDataRequest request, OrderItemFilter searchFilter)
        {
            IEnumerable<OrderItem> result = _service.Search(searchFilter);
            IEnumerable<OrderItemViewModel> resultView = Mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(result);
            foreach (OrderItemViewModel orderItem in resultView)
            {
                orderItem.TotalPrice = orderItem.ProductPrice * orderItem.Amount.Value;
            }
            return Json(GridDataResponse.Create(request, resultView, 0), JsonRequestBehavior.AllowGet);
        }

        protected override OrderItemViewModel GetViewModel(int entityId)
        {
            OrderItem entity = _service.Get(entityId);
            var model = Mapper.Map<OrderItem, OrderItemViewModel>(entity);
            model.TotalPrice = entity.Product.Price * entity.Amount;
            return model;
        }

        protected override void SetDefaultReturnUrl(OrderItemViewModel model)
        {
            model.RedirectUrl = Url.Action("Edit", "Order", new {id = model.OrderId});
        }

        protected override void PrepareModelToCreateView(OrderItemViewModel model)
        {
            PrepareModel(model);
        }
        protected override void PrepareModelToEditView(OrderItemViewModel model)
        {
            PrepareModel(model);
        }

        private void PrepareModel(OrderItemViewModel model)
        {
            IEnumerable<Product> products = _productService.Search(new DefaultSearchFilter());
            model.Products = new SelectList(products.Select(p => new { Value = p.ProductId, Text = p.Name }), "Value", "Text");
        }
    }
}
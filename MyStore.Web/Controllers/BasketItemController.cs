using System.Web.Mvc;
using MyStore.Core.Entities;
using MyStore.Core.Exceptions;
using MyStore.Core.SearchFilters;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class BasketItemController : BaseEntityController<BasketItemViewModel, BasketItem, IBasketItemService, BasketItemFilter>
    {
        public BasketItemController(IBasketItemService basketItemService)
            :base(basketItemService)
        {
        }

        public override void SetIndexTitle()
        {
            ViewBag.Title = "Basket";
        }

        [AjaxOnly]
        public ActionResult Add([Bind(Prefix = "id")]int productId)
        {
            if (!UserContext.ClientId.HasValue)
                throw new MyStoreGeneralException("The logged in user should be a Client");

            var bi = new BasketItem()
            {
                ClientId = UserContext.ClientId.Value,
                ProductId = productId,
                Amount = 1
            };
            _service.Create(bi);
            return JsonEx(true, "The product has been added to the basket");
        }

        /*
        public ActionResult GetItemsCount()
        {
            if (!UserContext.ClientId.HasValue)
                return Content(string.Empty);

            IEnumerable<BasketItem> items = _service.Search(new BasketItemFilter() {ClientId = UserContext.ClientId.Value});
            return Content(items.Count().ToString());
        }
        */

    }
}
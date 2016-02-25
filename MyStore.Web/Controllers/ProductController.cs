using Common.BL;
using MyStore.Core.Entities;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class ProductController : BaseEntityController<ProductViewModel, Product, IProductService, DefaultSearchFilter>
    {
        public ProductController(IProductService productService)
            :base(productService)
        {
        }

    }
}
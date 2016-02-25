using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using AutoMapper;
using Common.BL;
using Common.Web.Grid;

namespace MyStore.Web.Common
{
    [Authorize]
    public abstract class BaseEntityController<TEntityViewModel, TEntity, TService, TSearchFilter> : BaseController
        where TEntityViewModel : class, IViewModel, new()
        where TEntity : class, new()
        where TService : IBaseService<TEntity, TSearchFilter>
        where TSearchFilter : DefaultSearchFilter
    {
        protected readonly TService _service;

        [Dependency]
        public IMapper Mapper { get; set; }

        protected BaseEntityController(TService service)
        {
            _service = service;
        }

        public virtual void SetIndexTitle()
        {
            ViewBag.Title = typeof (TEntity).Name + "s";
        }

        public virtual ActionResult Index()
        {
            SetIndexTitle();
            return View();
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return Create(x => { });
        }

        protected ActionResult Create(Action<TEntityViewModel> prepareModelAction)
        {
            var model = new TEntityViewModel();
            SetDefaultReturnUrl(model);

            prepareModelAction?.Invoke(model);

            PrepareModelToCreateView(model);
            return CreateView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TEntityViewModel model)
        {
            if (ModelState.IsValid)
            {
                DoCreate(model);

                if (Request.IsAjaxRequest())
                    return JsonEx();

                return RedirectTo(model);
            }

            PrepareModelToCreateView(model);
            return CreateView(model);
        }

        protected virtual void DoCreate(TEntityViewModel model)
        {
            TEntity entity = Mapper.Map<TEntityViewModel, TEntity>(model);
            _service.Create(entity);
        }
        protected ActionResult CreateView(object model)
        {
            if (Request.IsAjaxRequest())
                return PartialView("_Create", model);

            return View("Create", model);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            TEntityViewModel model = GetViewModel(id);
            SetDefaultReturnUrl(model);
            PrepareModelToEditView(model);
            return EditView(model);
        }

        protected virtual TEntityViewModel GetViewModel(int entityId)
        {
            TEntity entity = _service.Get(entityId);
            return Mapper.Map<TEntity, TEntityViewModel>(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEntityViewModel model)
        {
            if (ModelState.IsValid)
            {
                DoUpdate(model);

                if (Request.IsAjaxRequest())
                    return JsonEx();

                return RedirectTo(model);
            }

            PrepareModelToEditView(model);
            return EditView(model);
        }

        protected virtual void DoUpdate(TEntityViewModel model)
        {
            TEntity entity = _service.Get(model.EntityId);
            entity = Mapper.Map<TEntityViewModel, TEntity>(model, entity);
            _service.Update(entity);
        }
        private ActionResult EditView(object model)
        {
            if (Request.IsAjaxRequest())
                return PartialView("_Edit", model);

            return View(model);
        }

        [AjaxOnly]
        public virtual ActionResult Get(int id)
        {
            TEntity entity = _service.Get(id);
            TEntityViewModel model = Mapper.Map<TEntity, TEntityViewModel>(entity);
            return JsonEx(model, JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        public virtual ActionResult GridSearch(GridDataRequest request, TSearchFilter searchFilter)
        {
            IEnumerable<TEntity> result = _service.Search(searchFilter);
            IEnumerable<TEntityViewModel> resultView = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TEntityViewModel>>(result);
            return Json(GridDataResponse.Create(request, resultView, 0), JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        [HttpPost]
        public virtual ActionResult Delete(int id)
        {
            _service.Delete(id);
            return JsonEx();
        }

        protected virtual void PrepareModelToCreateView(TEntityViewModel model)
        {
        }
        protected virtual void PrepareModelToEditView(TEntityViewModel model)
        {
        }

        protected void SetFormAttributes(object htmlAttributes)
        {
            ViewBag.HtmlFormAttributes = htmlAttributes;
        }

        protected virtual void SetDefaultReturnUrl(TEntityViewModel model)
        {
            if (model.RedirectUrl != null)
                return;

            if (Request.UrlReferrer != null)
                model.RedirectUrl = Request.UrlReferrer.ToString();
        }

        protected virtual ActionResult RedirectTo(TEntityViewModel model)
        {
            if (model.RedirectUrl == null)
                return RedirectToAction("Index");

            return Redirect(model.RedirectUrl);
        }

    }
}

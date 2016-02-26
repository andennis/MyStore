using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
                TEntity entity = Mapper.Map<TEntityViewModel, TEntity>(model);
                _service.Create(entity);
                return RedirectTo(model);
            }

            PrepareModelToCreateView(model);
            return CreateView(model);
        }

        protected ActionResult CreateView(object model)
        {
            return View("Create", model);
        }

        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            TEntity entity = _service.Get(id);
            TEntityViewModel model = Mapper.Map<TEntity, TEntityViewModel>(entity);

            SetDefaultReturnUrl(model);
            return EditView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEntityViewModel model)
        {
            if (ModelState.IsValid)
            {
                TEntity entity = _service.Get(model.EntityId);
                entity = Mapper.Map<TEntityViewModel, TEntity>(model, entity);
                _service.Update(entity);

                return RedirectTo(model);
            }

            return EditView(model);
        }

        private ActionResult EditView(object model)
        {
            return View(model);
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

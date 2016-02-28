using System.Web.Mvc;

namespace MyStore.Web.Common
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            UserContext = new UserContext();
        }

        protected UserContext UserContext { get; }

        protected virtual JsonResult JsonEx(bool success = true, string message = null)
        {
            return JsonEx(null, success, message);
        }
        protected virtual JsonResult JsonEx(object data, bool success = true, string message = null)
        {
            return JsonEx(data, JsonRequestBehavior.DenyGet, success, message);
        }
        protected virtual JsonResult JsonEx(object data, JsonRequestBehavior behavior, bool success = true, string message = null)
        {
            var ajaxResp = new AjaxActionResponse()
            {
                Data = data,
                Success = success,
                Message = message
            };
            return Json(ajaxResp, behavior);
        }

    }
}
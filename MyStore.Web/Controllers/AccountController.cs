using System.Web.Mvc;
using System.Web.Security;
using MyStore.Core.Entities;
using MyStore.Core.Services;
using MyStore.Web.Common;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;

        public AccountController(IUserService userService, IClientService clientService)
        {
            _userService = userService;
            _clientService = clientService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_userService.IsAuthenticated(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    User user = _userService.Get(model.UserName);
                    Client client = _clientService.GetByUser(user.UserId);
                    UserContext.UserId = user.UserId;
                    UserContext.ClientId = client?.ClientId;

                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Authentication failed");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

    }
}
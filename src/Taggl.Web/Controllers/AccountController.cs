using Microsoft.AspNet.Mvc;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Exceptions;
using Taggl.Web.Utility;
using Taggl.Web.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Web.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ISessionService _sessionService;

        public AccountController(
            ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                try
                {
                    await _sessionService.Login(model.Map());
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                catch (IdentityErrorException ex)
                {
                    ModelState.AddIdentityErrors(ex);
                }
            }
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("log-out")]
        public async Task<IActionResult> Logout()
        {
            await _sessionService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}

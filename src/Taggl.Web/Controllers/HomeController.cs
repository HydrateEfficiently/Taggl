using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;

namespace Taggl.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IIdentityResolver _identityResolver;

        public HomeController(
            IIdentityResolver identityResolver)
        {
            _identityResolver = identityResolver;
        }

        [Route("")]
        public IActionResult Index()
        {
            if (_identityResolver.IsSignedIn())
            {
                return View("App");
            }
            return View();
        }
    }
}

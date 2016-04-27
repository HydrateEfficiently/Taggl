using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;
using Taggl.Services;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Models;

namespace Taggl.Web.Controllers.Api.Identity
{
    [Route("api/identity/user")]
    public class UserApiController : Controller
    {
        private readonly IUserService _userService;
        private readonly IIdentityResolver _identityResolver;

        public UserApiController(
            IUserService userService,
            IIdentityResolver identityResolver)
        {
            _userService = userService;
            _identityResolver = identityResolver;
        }
        
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _userService.GetAsync(id);
            if (result == null)
            {
                HttpNotFound();
            }
            return new ObjectResult(result);
        }
    }
}
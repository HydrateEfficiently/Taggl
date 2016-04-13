using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Models;

namespace Taggl.Web.Controllers.Api
{
    [Route("account")]
    public class AccountApiController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IIdentityResolver _identityResolver;
        private readonly IAccountService _accountService;

        public AccountApiController(
            ISessionService sessionService,
            IIdentityResolver identityResolver,
            IAccountService accountService)
        {
            _sessionService = sessionService;
            _identityResolver = identityResolver;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("log-out")]
        public async Task<IActionResult> Logout()
        {
            await _sessionService.Logout();
            return Ok();
        }

        [HttpPost]
        [Route("personal-information/update")]
        public async Task<IActionResult> UpdatePersonalInformation([FromBody] PersonalInformationUpdate update)
        {
            var result = await _accountService.UpdatePersonalInformationAsync(update);
            return new ObjectResult(result);
        }
    }
}

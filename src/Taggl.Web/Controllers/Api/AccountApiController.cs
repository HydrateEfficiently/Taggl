using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity;

namespace Taggl.Web.Controllers.Api
{
    public class AccountApiController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountApiController(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("log-out")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok();
        }
    }
}

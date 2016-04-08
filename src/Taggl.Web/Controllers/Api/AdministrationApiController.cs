using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;
using Taggl.Services.Administrator;

namespace Taggl.Web.Controllers.Api
{
    [Authorize(Roles = ApplicationRoles.Administrator)]
    [Route("api/administration")]
    public class AdministrationApiController : Controller
    {
        private readonly AdministrationService _administrationService;

        public AdministrationApiController(
            AdministrationService administrationService)
        {
            _administrationService = administrationService;
        }

        [HttpGet]
        [Route("list-pending-users")]
        public async Task<IActionResult> ListPendingUsers()
        {
            var result = await _administrationService.ListPendingUsersAsync();
            return new ObjectResult(result);
        }

        [Route("approve-user/{userId}")]
        public async Task<IActionResult> ApproveUser(string userId)
        {
            await _administrationService.ApproveUserAsync(userId);
            return Ok();
        }
    }
}

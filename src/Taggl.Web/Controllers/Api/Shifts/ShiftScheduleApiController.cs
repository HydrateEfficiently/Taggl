using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Taggl.Framework.Services;
using Taggl.Services;
using Taggl.Services.Shifts;
using Taggl.Services.Shifts.Models;

namespace Taggl.Web.Controllers.Api.Shifts
{
    [Route("api/shifts/shiftSchedule")]
    public class ShiftScheduleApiController : Controller
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        private readonly IIdentityResolver _identityResolver;

        public ShiftScheduleApiController(
            IShiftScheduleService shiftScheduleService,
            IIdentityResolver identityResolver)
        {
            _shiftScheduleService = shiftScheduleService;
            _identityResolver = identityResolver;
        }
        
        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> List([FromBody] DateTime date)
        {
            var identityId = _identityResolver.Resolve().GetUserId();
            var result = await _shiftScheduleService.ListAsync(identityId, date);
            if (result == null)
            {
                HttpNotFound();
            }
            return new ObjectResult(result);
        }
        
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _shiftScheduleService.GetAsync(id);
            if (result == null)
            {
                HttpNotFound();
            }
            return new ObjectResult(result);
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ShiftScheduleCreate create)
        {
            var result = await _shiftScheduleService.CreateAsync(create);
            if (result == null)
            {
                HttpNotFound();
            }
            return new ObjectResult(result);
        }
        
        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _shiftScheduleService.DeleteAsync(id);
            return Ok();
        }
    }
}
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Shifts;
using Taggl.Services.Shifts.Models;

namespace Taggl.Web.Controllers.Api.Shifts
{
    [Route(ApiControllerRouteTemplates.ShiftScheduleRouteTemplate)]
    public class ShiftScheduleApiController  : Controller
    {
        private readonly IShiftScheduleService _shiftScheduleService;

        public ShiftScheduleApiController(
            IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ShiftScheduleCreate create)
        {
            var result = await _shiftScheduleService.CreateAsync(create);
            return new ObjectResult(result);
        }
    }
}

using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Shifts.Models;
using Taggl.Services.Professionalities;

namespace Taggl.Web.Controllers.Api.Professionalities
{
    [Route(ApiControllerRouteTemplates.ExpertiseRouteTemplate)]
    public class ExpertiseApiController : Controller
    {
        private readonly IExpertiseService _expertiseService;

        public ExpertiseApiController(
            IExpertiseService expertiseService)
        {
            _expertiseService = expertiseService;
        }

        public async Task<IActionResult> Create(ShiftTypeCreate create)
        {
            var result = await _expertiseService.CreateAsync(create);
            return new ObjectResult(result);
        }
    }
}

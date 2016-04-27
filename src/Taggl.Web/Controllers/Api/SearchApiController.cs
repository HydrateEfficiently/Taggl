using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Gyms;
using Taggl.Services.Identity;
using Taggl.Services.Shifts;

namespace Taggl.Web.Controllers.Api
{
    [Route("api/search")]
    public class SearchApiController : Controller
    {
        private readonly IUserSearchService _userSearchService;
        private readonly IShiftTypeSearchService _shiftTypeSearchService;
        private readonly IShiftTypeService _shiftTypeService;
        private readonly IGymSearchService _gymSearchService;
        private readonly IGymService _gymService;

        public SearchApiController(
            IUserSearchService userSearchService,
            IShiftTypeSearchService shiftTypeSearchService,
            IShiftTypeService shiftTypeService,
            IGymSearchService gymSearchService,
            IGymService gymService)
        {
            _userSearchService = userSearchService;
            _shiftTypeSearchService = shiftTypeSearchService;
            _shiftTypeService = shiftTypeService;
            _gymSearchService = gymSearchService;
            _gymService = gymService;
        }

        [HttpGet]
        [Route("users/{pattern}")]
        public async Task<IActionResult> Users(string pattern)
        {
            var result = await _userSearchService.Search(pattern);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("shift-types/{pattern}")]
        public async Task<IActionResult> ShiftTypes(string pattern)
        {
            object result;
            Guid id;
            if (Guid.TryParse(pattern, out id))
            {
                result = await _shiftTypeService.GetAsync(id);
            }
            else
            {
                result = await _shiftTypeSearchService.Search(pattern);
            }
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("gyms/{pattern}")]
        public async Task<IActionResult> Gyms(string pattern)
        {
            object result;
            Guid id;
            if (Guid.TryParse(pattern, out id))
            {
                result = await _gymService.GetAsync(id);
            }
            else
            {
                result = await _gymSearchService.Search(pattern);
            }
            return new ObjectResult(result);
        }
    }
}

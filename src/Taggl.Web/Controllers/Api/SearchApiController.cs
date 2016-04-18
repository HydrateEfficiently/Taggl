using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity;
using Taggl.Services.Shifts;

namespace Taggl.Web.Controllers.Api
{
    [Route("api/search")]
    public class SearchApiController : Controller
    {
        private readonly IUserSearchService _userSearchService;
        private readonly IShiftTypeSearchService _shiftTypeSearchService;

        public SearchApiController(
            IUserSearchService userSearchService,
            IShiftTypeSearchService shiftTypeSearchService)
        {
            _userSearchService = userSearchService;
            _shiftTypeSearchService = shiftTypeSearchService;
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
            var result = await _shiftTypeSearchService.Search(pattern);
            return new ObjectResult(result);
        }
    }
}

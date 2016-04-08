using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity;

namespace Taggl.Web.Controllers.Api
{
    [Route("api/search")]
    public class SearchApiController : Controller
    {
        private readonly IUserSearchService _userSearchService;

        public SearchApiController(
            IUserSearchService userSearchService)
        {
            _userSearchService = userSearchService;
        }

        [Route("users/{pattern}")]
        public async Task<IActionResult> Users(string pattern)
        {
            var result = await _userSearchService.Search(pattern);
            return new ObjectResult(result);
        }
    }
}

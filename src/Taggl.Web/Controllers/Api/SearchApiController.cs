using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity;
using Taggl.Services.Jobs;

namespace Taggl.Web.Controllers.Api
{
    [Route("api/search")]
    public class SearchApiController : Controller
    {
        private readonly IUserSearchService _userSearchService;
        private readonly IJobTagSearchService _jobTagSearchService;

        public SearchApiController(
            IUserSearchService userSearchService,
            IJobTagSearchService jobTagSearchService)
        {
            _userSearchService = userSearchService;
            _jobTagSearchService = jobTagSearchService;
        }

        [HttpGet]
        [Route("users/{pattern}")]
        public async Task<IActionResult> Users(string pattern)
        {
            var result = await _userSearchService.Search(pattern);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("job-tags/{pattern}")]
        public async Task<IActionResult> JobTags(string pattern)
        {
            var result = await _jobTagSearchService.Search(pattern);
            return new ObjectResult(result);
        }
    }
}

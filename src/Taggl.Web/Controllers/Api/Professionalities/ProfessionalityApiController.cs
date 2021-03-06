﻿using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Professionalities;
using Taggl.Services.Professionalities.Models;

namespace Taggl.Web.Controllers.Api.Professionalities
{
    [Route(ApiControllerRouteTemplates.ProfessionalityRouteTemplate)]
    public class ProfessionalityApiController : Controller
    {
        private readonly IProfessionalityService _professionalityService;
        private readonly IIdentityResolver _identityResolver;

        public ProfessionalityApiController(
            IProfessionalityService professionalityService,
            IIdentityResolver identityResolver)
        {
            _professionalityService = professionalityService;
            _identityResolver = identityResolver;
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var identityId = _identityResolver.Resolve().GetId();
            var result = await _professionalityService.GetAsync(identityId);
            return new ObjectResult(result);
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ProfessionalityUpdate update)
        {
            var result = await _professionalityService.UpdateAsync(update);
            return new ObjectResult(result);
        }
    }
}

﻿using Azn.RiskApp.Web.Services.Framework._Dev;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Web.Controllers._Dev
{
    [Route("_dev")]
    public class _DevController : Controller
    {
        [HttpGet]
        [Route("emails")]
        public IActionResult Emails()
        {
            return View(System.IO.File.ReadAllLines(DevCsvEmailService.FilePath));
        }
    }
}

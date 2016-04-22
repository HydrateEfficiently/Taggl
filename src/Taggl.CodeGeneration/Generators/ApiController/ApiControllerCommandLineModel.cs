using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;

namespace Taggl.CodeGeneration.Generators.ApiController
{
    public class ApiControllerCommandLineModel : CommandLineModel
    {
        [Option(Name = "service", ShortName = "s", Description = "The service to base the controller off")]
        public string Service { get; set; }

        [Option(Name = "inject", ShortName = "i", Description = "The extra services (comma separated) to inject into the controller")]
        public string Inject { get; set; }
    }
}

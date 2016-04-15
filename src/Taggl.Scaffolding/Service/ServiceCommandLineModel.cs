using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Scaffolding.Sevice
{
    public class ServiceCommandLineModel : CommandLineModel
    {
        [Option(Name = "entity", ShortName = "e", Description = "The path to the entity from Framework/Models")]
        public string Entity { get; set; }
    }
}

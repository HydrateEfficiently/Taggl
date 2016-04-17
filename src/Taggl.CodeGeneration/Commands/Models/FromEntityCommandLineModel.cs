using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Commands.Models
{
    public class FromEntityCommandLineModel : CommandLineModel
    {
        [Option(Name = "entity", ShortName = "e", Description = "The path to the entity from Framework/Models")]
        public string Entity { get; set; }
    }
}

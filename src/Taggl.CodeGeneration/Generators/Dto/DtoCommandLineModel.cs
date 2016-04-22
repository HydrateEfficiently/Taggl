using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;

namespace Taggl.CodeGeneration.Generators.Dto
{
    public class DtoCommandLineModel : FromEntityCommandLineModel
    {
        [Option(Name = "auditDelete", ShortName = "d", Description = "A flag which determines if the read DTO should be generated")]
        public bool Read { get; set; }

        [Option(Name = "create", ShortName = "c", Description = "A flag which determines if the create DTO should be generated")]
        public bool Create { get; set; }

        [Option(Name = "update", ShortName = "u", Description = "A flag which determines if the update DTO should be generated")]
        public bool Update { get; set; }
    }
}

using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands;

namespace Taggl.CodeGeneration.Generators.Entity
{
    public class EntityCommandLineModel : FromEntityCommandLineModel
    {
        [Option(Name = "area", ShortName = "a", Description = "The namespace name below the root entities namespace.")]
        [Required]
        public string Area { get; set; }
    }
}

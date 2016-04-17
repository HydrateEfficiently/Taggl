using Microsoft.Extensions.CodeGeneration.CommandLine;

namespace Taggl.CodeGeneration.Commands
{
    public abstract class CommandLineModel
    {
        [Option(Name = "force", ShortName = "f", Description = "Use this option to overwrite existing files")]
        public bool Force { get; set; }
    }
}
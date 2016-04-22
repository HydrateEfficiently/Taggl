using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;
using Taggl.CodeGeneration.Generators.DtoMappings;
using Taggl.CodeGeneration.Generators.Entity;

namespace Taggl.CodeGeneration.Commands
{
    [Alias("mappings")]
    public class DtoMappingsGenerateCommand : FromEntityGenerateCommand
    {
        public DtoMappingsGenerateCommand(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task GenerateCode(FromEntityCommandLineModel model)
        {
            ValidateCommandLineModel(model);
            await GetGenerator<DtoMappingsGenerator>(model).Generate();
        }
    }
}

using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Generators.Dto;

namespace Taggl.CodeGeneration.Commands
{
    [Alias("dto")]
    public class DtoGenerateCommand : FromEntityGenerateCommand
    {
        public DtoGenerateCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task GenerateCode(DtoCommandLineModel model)
        {
            ValidateCommandLineModel(model);
            await GetGenerator<DtoGenerator>(model).Generate();
        }
    }
}

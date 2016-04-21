using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Generators.ReadDto;

namespace Taggl.CodeGeneration.Commands
{
    [Alias("dto-read")]
    public class ReadDtoGenerateCommand : FromEntityGenerateCommand
    {
        public ReadDtoGenerateCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task GenerateCode(ReadDtoCommandLineModel model)
        {
            await GetGenerator<ReadDtoGenerator>(model).Generate();
        }
    }
}

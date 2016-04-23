using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Generators.ApiController;

namespace Taggl.CodeGeneration.Commands
{
    [Alias("api")]
    public class ApiControllerGenerateComand : GenerateCommand
    {
        public ApiControllerGenerateComand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task GenerateCode(ApiControllerCommandLineModel model)
        {
            await GetGenerator<ApiControllerGenerator>(model).Generate();
        }
    }
}

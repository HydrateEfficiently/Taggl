using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Commands
{
    [Alias("api")]
    public class ApiControllerGenerateComand : GenerateCommand
    {
        public ApiControllerGenerateComand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}

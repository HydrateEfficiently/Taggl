using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands;
using Taggl.CodeGeneration.Generators.Entity;

namespace Taggl.CodeGeneration.Entity
{
    [Alias("entity")]
    public class EntityGenerateCommand : FromEntityGenerateCommand
    {
        public EntityGenerateCommand(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task GenerateCode(EntityCommandLineModel model)
        {
            ValidateCommandLineModel(model);

            var generator = GetGenerator<EntityGenerator>(model);
        }
    }
}

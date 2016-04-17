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

            if (string.IsNullOrWhiteSpace(model.Area))
            {
                throw new InvalidOperationException("Please specify an area with -a");
            }
            
            if (string.IsNullOrWhiteSpace(model.IdentityTypeName))
            {
                model.IdentityTypeName = "g";
            }
            else if (model.IdentityTypeName != "g" && model.IdentityTypeName != "i")
            {
                throw new InvalidOperationException("Invalid value for -i");
            }

            var generator = GetGenerator<EntityGenerator>(model);
            await generator.Generate();
        }
    }
}

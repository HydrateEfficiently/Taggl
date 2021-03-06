﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;
using Taggl.CodeGeneration.Services;

namespace Taggl.CodeGeneration.Commands
{
    public abstract class FromEntityGenerateCommand : GenerateCommand
    {
        public FromEntityGenerateCommand(
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            AddServiceWithDependency<IEntityReflector, EntityReflector>();
            AddServiceWithDependency<IEntityPropertyResolver, EntityPropertyResolver>();
            AddServiceWithDependency<IEntityOperationsResolver, EntityOperationsResolver>();
        }

        public void ValidateCommandLineModel(FromEntityCommandLineModel model)
        {
            if (string.IsNullOrEmpty(model.Entity))
            {
                throw new Exception("-e is required");
            }
        }
    }
}

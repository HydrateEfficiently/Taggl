using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services;

namespace Taggl.CodeGeneration
{
    public class EntityDependentCommandLineGeneratorBase : CommandLineGeneratorBase
    {
        public EntityDependentCommandLineGeneratorBase(
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            AddServiceWithDependency<IEntityReflector, EntityReflector>();
            AddServiceWithDependency<IEntityPropertyResolver, EntityPropertyResolver>();
            AddServiceWithDependency<IAreaNameResolver, AreaNameResolver>();
        }
    }
}

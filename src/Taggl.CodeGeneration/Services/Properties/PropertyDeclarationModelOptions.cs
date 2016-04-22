using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services.Properties
{
    public class PropertyDeclarationModelOptions
    {
        public string AccessModifier { get; internal set; } = "public";
        public bool IsVirtual { get; internal set; } = false;
    }
}

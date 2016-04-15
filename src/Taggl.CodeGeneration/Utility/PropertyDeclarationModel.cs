using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Utility
{
    public class PropertyDeclarationModel
    {
        public string Name { get; internal set; }
        public string ResolvedTypeName { get; internal set; }
    }
}

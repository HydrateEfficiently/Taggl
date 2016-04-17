using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services.Properties
{
    public class PropertyDeclarationModel
    {
        public string AccessModifier { get; internal set; }
        public string Name { get; internal set; }
        public string ResolvedTypeName { get; internal set; }
        public string ExtraModifiers { get; internal set; }
        public bool HasExtraModifier { get { return !string.IsNullOrEmpty(ExtraModifiers); } }
    }
}

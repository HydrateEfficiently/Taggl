using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Generators.ReadDto
{
    public class PropertyDeclarationModel
    {
        public string PropertyTypeName { get; internal set; }
        public string PropertyName { get; set; }
    }
}

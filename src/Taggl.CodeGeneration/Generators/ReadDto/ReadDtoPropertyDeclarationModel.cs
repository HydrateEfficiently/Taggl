using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.Properties;

namespace Taggl.CodeGeneration.Generators.ReadDto
{
    public class DtoPropertyDeclarationModel : PropertyDeclarationModel
    {
        public string BasePropertyTypeName { get; internal set; }
    }
}

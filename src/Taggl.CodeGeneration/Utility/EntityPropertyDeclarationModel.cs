using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Utility
{
    public class EntityPropertyDeclarationModel : PropertyDeclarationModel
    {
        public bool IsAuditProperty { get; set; }
    }
}

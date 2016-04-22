using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Core
{
    public class GeneratedEntityAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}

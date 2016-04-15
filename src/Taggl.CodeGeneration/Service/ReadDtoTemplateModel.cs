using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration.Service
{
    public class ReadDtoTemplateModel
    {
        public string EntityName { get; internal set; }
        public string EntityNamespaceName { get; internal set; }
        public IEnumerable<PropertyDeclarationModel> EntityProperties { get; internal set; }
        public string ReadEntityDtoName { get; internal set; }
        public string ServicesNamespaceName { get; internal set; }
    }
}

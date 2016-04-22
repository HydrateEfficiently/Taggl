using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.Properties;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration.Generators.ReadDto
{
    public class DtoTemplateModel
    {
        public string EntityName { get; internal set; }
        public string EntityNamespaceName { get; internal set; }
        public string DtoName { get; internal set; }
        public string NamespaceName { get; internal set; }
        public List<PropertyDeclarationModel> Properties { get; internal set; }
        public List<DtoPropertyDeclarationModel> DtoProperties { get; internal set; }
        public List<string> DtoNamespaceNames { get; internal set; }
    }
}

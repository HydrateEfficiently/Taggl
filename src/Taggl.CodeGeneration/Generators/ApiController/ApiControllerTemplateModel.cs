using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.CodeDeclarations;

namespace Taggl.CodeGeneration.Generators.ApiController
{
    public class ApiControllerTemplateModel
    {
        public IEnumerable<ActionDeclarationModel> Actions { get; internal set; }
        public string ClassName { get; internal set; }
        public List<MemberDeclarationModel> InjectedServices { get; internal set; }
        public string NamespaceName { get; internal set; }
        public MemberDeclarationModel Service { get; internal set; }
        public IEnumerable<string> UsingNamespaceNames { get; internal set; }
        public string ControllerRouteTemplate { get; set; }
    }
}

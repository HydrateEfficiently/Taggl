using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.CodeDeclarations;

namespace Taggl.CodeGeneration.Generators.ApiController
{
    public class ActionDeclarationModel
    {
        public IEnumerable<string> Attributes { get; internal set; } = Enumerable.Empty<string>();
        public MethodDeclarationModel Method { get; internal set; }
        public ServiceMethodInvocationModel ServiceMethod { get; internal set; }
        
        public bool IsAsync
        {
            get
            {
                return ServiceMethod.IsAsync;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services.CodeDeclarations
{
    public class MethodDeclarationModel
    {
        public string AccessModifier { get; internal set; } = "public";
        public string ReturnTypeName { get; internal set; } = "void";
        public bool IsAsync { get; internal set; } = false;
        public IEnumerable<string> Parameters { get; internal set; } = Enumerable.Empty<string>();

        public IEnumerable<string> ParameterNames
        {
            get
            {
                return Parameters.Select(p => p.Split(' ').Last());
            }
        }
    }
}

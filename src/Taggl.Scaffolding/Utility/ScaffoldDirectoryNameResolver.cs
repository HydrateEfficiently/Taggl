using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Scaffolding.Utility
{
    public class ScaffoldDirectoryNameResolver
    {
        public ScaffoldDirectoryNameResolver() { }

        public string ResolveDirectoryName(ScaffoldType scaffoldType)
        {
            switch (scaffoldType)
            {
                case ScaffoldType.Service:
                    return "Service";
                default:
                    throw new Exception("Unknown scaffold type");
            }
        }
    }
}

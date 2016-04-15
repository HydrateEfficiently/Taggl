using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Utility
{
    public class NameResolver
    {
        private readonly string _rootNamespace;

        public NameResolver(
            ILibraryManager libraryManager,
            IApplicationEnvironment appEnvironment)
        {
            string appName = libraryManager.GetLibrary(appEnvironment.ApplicationName).Name;
            _rootNamespace = appName.Split('.')[0];
        }

        public string GetRootNamespace()
        {
            return _rootNamespace;
        }

        public string GetFrameworkNamespace()
        {
            return $"{GetRootNamespace()}.Framework";
        }

        public string GetModelsNamespace()
        {
            return $"{GetFrameworkNamespace()}.Models";
        }

        public string GetEntityNamespace(string modelName)
        {
            return $"{GetModelsNamespace()}.{modelName}";
        }

        public string GetServicesNamespace()
        {
            return $"{GetRootNamespace()}.Services";
        }
    }
}

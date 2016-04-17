using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services
{
    public class NamespaceService
    {
        private readonly string _rootNamespace;

        public NamespaceService(
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

        public string GetFrameworkEntitiesNamespace()
        {
            return $"{GetFrameworkNamespace()}.Models";
        }

        public string GetFrameworkEntityNamespace(string areaName)
        {
            return $"{GetFrameworkEntitiesNamespace()}.{areaName}";
        }

        public string GetFrameworkServicesNamespace()
        {
            return $"{GetFrameworkNamespace()}.Services";
        }

        public string GetServicesNamespace()
        {
            return $"{GetRootNamespace()}.Services";
        }

        public string GetServiceNamespace(string areaName)
        {
            return $"{GetServicesNamespace()}.{areaName}";
        }

        public string GetServiceModelsNamespace(string areaName)
        {
            return $"{GetServiceNamespace(areaName)}.Models";
        }
    }
}

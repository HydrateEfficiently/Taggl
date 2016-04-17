using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services
{
    public interface IAssemblyProvider
    {
        Assembly GetFrameworkAssembly();

        Assembly GetServicesAssembly();

        Assembly GetWebAssembly();
    }

    public class AssemblyProvider : IAssemblyProvider
    {
        private readonly NamespaceService _namespaceService;

        public AssemblyProvider(
            NamespaceService namespaceService)
        {
            _namespaceService = namespaceService;
        }

        public Assembly GetFrameworkAssembly()
        {
            return GetAssembly(_namespaceService.GetFrameworkNamespace());
        }

        public Assembly GetServicesAssembly()
        {
            return GetAssembly(_namespaceService.GetServicesNamespace());
        }

        public Assembly GetWebAssembly()
        {
            return GetAssembly(_namespaceService.GetWebNamespace());
        }

        #region Helpers

        private Assembly GetAssembly(string namespaceName)
        {
            var namespaceAssemblyName = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Where(a => a.Name == namespaceName)
                .FirstOrDefault();

            if (namespaceAssemblyName == null)
            {
                throw new InvalidOperationException($"Could not find assembly with name {namespaceName}");
            }

            return Assembly.Load(namespaceName);
        }

        #endregion
    }
}

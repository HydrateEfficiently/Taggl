using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services
{
    public interface IAreaNameResolver
    {
        string Resolve(string entityName);
    }

    public class AreaNameResolver : IAreaNameResolver
    {
        private readonly IEntityReflector _entityReflector;
        private readonly NamespaceService _namespaceService;

        private Dictionary<string, string> _areaNamesByEntityName =
            new Dictionary<string, string>();

        public AreaNameResolver(
            IEntityReflector entityReflector,
            NamespaceService namespaceService)
        {
            _entityReflector = entityReflector;
            _namespaceService = namespaceService;
        }

        public string Resolve(string entityName)
        {
            string areaName;
            if (!_areaNamesByEntityName.TryGetValue(entityName, out areaName))
            {
                string entitiesNamespace = _namespaceService.GetFrameworkEntitiesNamespace();
                var entityNameQualifiedFromModels = _entityReflector.GetEntityType(entityName).FullName
                    .Replace($"{entitiesNamespace}.", string.Empty)
                    .Split('.');
                if (entityNameQualifiedFromModels.Count() != 2)
                {
                    throw new InvalidOperationException($"Entity namespace must be one below {entitiesNamespace}");
                }
                areaName = entityNameQualifiedFromModels.First();
                _areaNamesByEntityName.Add(entityName, areaName);
            }
            return areaName;
        }
    }
}

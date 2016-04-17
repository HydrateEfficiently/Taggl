using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration.Services
{
    public interface IEntityReflector
    {
        Type GetEntityType(string entityName);

        bool TryGetEntityType(string entityName, out Type entityType);

        string GetEntityIdType(string entityName);

        Type GetDataContextType();

        string GetDataSetPropertyName(string entityName);
    }

    public class EntityReflector : IEntityReflector
    {
        private readonly NamespaceService _namespaceService;
        private readonly IAssemblyProvider _assemblyProvider;

        private Type _dbContextType;
        private Dictionary<string, Type> _entityTypesByEntityName = new Dictionary<string, Type>();
        private Dictionary<string, string> _entityIdTypeNamesByEntityName = new Dictionary<string, string>();
        private Dictionary<string, string> _dbSetPropertyNamesByEntityName = new Dictionary<string, string>();

        public EntityReflector(
            NamespaceService namespaceService,
            IAssemblyProvider assemblyProvider)
        {
            _namespaceService = namespaceService;
            _assemblyProvider = assemblyProvider;
        }

        public Type GetEntityType(string entityName)
        {
            Type entityType;
            if (!_entityTypesByEntityName.TryGetValue(entityName, out entityType))
            {
                var frameworkAssembly = _assemblyProvider.GetFrameworkAssembly();
                var entityTypes = frameworkAssembly.GetTypes().Where(t => t.Name == entityName);
                if (entityTypes.Count() == 0)
                {
                    throw new InvalidOperationException(
                        $"Could not find entity of type {entityName}");
                }
                else if (entityTypes.Count() > 1)
                {
                    throw new InvalidOperationException(
                        $"Found multiple entities: ${string.Join(", ", entityTypes.Select(e => e.FullName))}");
                }
                entityType = entityTypes.Single();
                _entityTypesByEntityName.Add(entityName, entityType);
            }
            return entityType;
        }

        public bool TryGetEntityType(string entityName, out Type entityType)
        {
            try
            {
                entityType = GetEntityType(entityName);
                return true;
            }
            catch (InvalidOperationException)
            {
                entityType = null;
                return false;
            }
        }

        public string GetEntityIdType(string entityName)
        {
            string entityIdTypeName;
            if (!_entityIdTypeNamesByEntityName.TryGetValue(entityName, out entityIdTypeName))
            {
                var entityIdType = GetEntityType(entityName)
                    .GetProperties()
                    .Where(pi => pi.Name == "Id")
                    .FirstOrDefault();
                if (entityIdType == null)
                {
                    throw new InvalidOperationException("Entity must be keyed by a property named Id");
                }
                entityIdTypeName = entityIdType.PropertyType.Name;
                _entityIdTypeNamesByEntityName.Add(entityName, entityIdTypeName);
            }
            return entityIdTypeName;
        }

        public Type GetDataContextType()
        {
            if (_dbContextType == null)
            {
                string servicesNamespace = _namespaceService.GetServicesNamespace();
                string dbContextTypeName = $"{servicesNamespace}.ApplicationDbContext";
                _dbContextType = Type.GetType($"{dbContextTypeName},{servicesNamespace}");
                if (_dbContextType == null)
                {
                    throw new InvalidOperationException(
                        $"Could not find data context of type {dbContextTypeName} in assembly {servicesNamespace}");
                }
            }
            return _dbContextType;
        }

        public string GetDataSetPropertyName(string entityName)
        {
            string dbSetPropertyName;
            if (!_dbSetPropertyNamesByEntityName.TryGetValue(entityName, out dbSetPropertyName))
            {
                var genericDbSetType = typeof(DbSet<>);
                var dbSetType = genericDbSetType.MakeGenericType(GetEntityType(entityName));
                var dbContextType = GetDataContextType();
                var dbSetProperty = dbContextType
                    .GetProperties()
                    .Where(pi => pi.PropertyType == dbSetType)
                    .FirstOrDefault();
                if (dbSetProperty == null)
                {
                    throw new Exception(
                        $"Could not find property with type DbSet<{entityName}> on {dbContextType.Name}");
                }
                dbSetPropertyName = dbSetProperty.Name;
                _dbSetPropertyNamesByEntityName.Add(entityName, dbSetPropertyName);
            }
            return dbSetPropertyName;
        }
    }
}

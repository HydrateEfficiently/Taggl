using Microsoft.Data.Entity;
using Microsoft.Extensions.CodeGeneration;
using Microsoft.Extensions.CodeGeneration.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;
using Taggl.Scaffolding.Sevice;
using Taggl.Scaffolding.Utility;

namespace Taggl.Scaffolding.Service
{
    [Alias("service")]
    public class ServiceCommandLineGenerator : ICodeGenerator
    {
        private const string ServiceSuffix = "Service";

        private readonly IServiceProvider _serviceProvider;
        private readonly Scaffolder _scaffolder;
        private readonly NameResolver _nameResolver;

        public ServiceCommandLineGenerator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _scaffolder = ActivatorUtilities.CreateInstance<Scaffolder>(_serviceProvider);
            _nameResolver = ActivatorUtilities.CreateInstance<NameResolver>(_serviceProvider);
        }

        public async Task GenerateCode(ServiceCommandLineModel model)
        {
            if (string.IsNullOrEmpty(model.Entity))
            {
                throw new Exception("-e is required");
            }

            string frameworkNamespace = _nameResolver.GetFrameworkNamespace();
            var frameworkAssembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith(frameworkNamespace))
                .FirstOrDefault();
            if (frameworkAssembly == null)
            {
                throw new InvalidOperationException($"Could not find assembly with name {frameworkAssembly.FullName}");
            }

            var entityName = model.Entity;
            var entityTypes = frameworkAssembly.GetTypes().Where(t => t.Name == entityName);
            if (entityTypes.Count() == 0)
            {
                throw new InvalidOperationException($"Could not find entity of type ${model.Entity} in assembly {frameworkNamespace}");
            }
            else if (entityTypes.Count() > 1)
            {
                throw new InvalidOperationException($"Found multiple entities: ${string.Join(", ", entityTypes.Select(e => e.FullName))}");
            }
            var entityType = entityTypes.Single();

            var modelNamespace = _nameResolver.GetModelsNamespace();
            var entityNameQualifiedFromModels = entityType.FullName
                .Replace($"{modelNamespace}.", string.Empty)
                .Split('.');
            if (entityNameQualifiedFromModels.Count() != 2)
            {
                throw new InvalidOperationException($"Entity must be two folders below {modelNamespace}");
            }
            string areaName = entityNameQualifiedFromModels.First();

            var entityIdType = entityType
                .GetProperties()
                .Where(pi => pi.Name == "Id")
                .FirstOrDefault();
            if (entityIdType == null)
            {
                throw new InvalidOperationException("Entity must be keyed by a property named Id");
            }
            string entityIdTypeName = entityIdType.Name;

            string servicesNamespaceName = _nameResolver.GetServicesNamespace();
            string dbContextTypeName = $"{servicesNamespaceName}.ApplicationDbContext";
            var dbContextType = Type.GetType($"{dbContextTypeName},{servicesNamespaceName}");
            if (dbContextType == null)
            {
                throw new InvalidOperationException($"Could not find data context of type {dbContextTypeName} in assembly {servicesNamespaceName}");
            }

            var genericDbSetType = typeof(DbSet<>);
            var dbSetType = genericDbSetType.MakeGenericType(entityType);
            var dbSetProperty = dbContextType
                .GetProperties()
                .Where(pi => pi.PropertyType == dbSetType)
                .FirstOrDefault();
            if (dbSetProperty == null)
            {
                throw new Exception($"Could not find property with type DbSet<{entityName}> on {dbContextTypeName}");
            }
            var dbSetPropertyName = dbSetProperty.Name;

            bool canUpdate = typeof(IUpdateAuditable).IsAssignableFrom(entityType);
            bool canDelete = typeof(IDeleteAuditable).IsAssignableFrom(entityType);
            bool canList = true; // TODO

            string readEntityDtoName = $"{entityName}Result";
            string createEntityDtoName = $"Create{entityName}";
            string updateEntityDtoName = $"Update{entityName}";

            string serviceName = $"{entityName}{ServiceSuffix}";
            string serviceNamespaceName = $"{servicesNamespaceName}.{areaName}";
            string entitiesNamespaceName = _nameResolver.GetModelsNamespace();
            string entityNamespaceName = _nameResolver.GetEntityNamespace(entityName);
            dynamic templateModel = new ServiceTemplateModel()
            {
                EntityName = entityName,
                AreaName = areaName,
                ServiceName = serviceName,
                ServiceNamespaceName = serviceNamespaceName,
                EntitiesNamespaceName = entitiesNamespaceName,
                EntityNamespaceName = entityNamespaceName,
                DbSetPropertyName = dbSetPropertyName,
                EntityIdTypeName = entityIdTypeName,
                CanUpdate = canUpdate,
                CanDelete = canDelete,
                CanList = canList,
                ReadEntityDtoName = readEntityDtoName,
                CreateEntityDtoName = createEntityDtoName,
                UpdateEntityDtoName = updateEntityDtoName
            };

            var scaffolder = ActivatorUtilities.CreateInstance<Scaffolder>(_serviceProvider);
            await _scaffolder.ScaffoldServiceAsync(areaName, entityName, serviceName, templateModel, model.Force);
        }
    }
}

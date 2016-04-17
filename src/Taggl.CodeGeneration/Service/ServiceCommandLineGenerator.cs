using Microsoft.Data.Entity;
using Microsoft.Extensions.CodeGeneration;
using Microsoft.Extensions.CodeGeneration.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;
using Taggl.CodeGeneration.Sevice;
using Taggl.CodeGeneration.Utility;
using System.Reflection;
using Taggl.CodeGeneration.Services;

namespace Taggl.CodeGeneration.Service
{
    [Alias("service")]
    public class ServiceCommandLineGenerator : EntityDependentCommandLineGeneratorBase
    {
        private const string ServiceSuffix = "Service";

        public ServiceCommandLineGenerator(
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        public async Task GenerateCode(ServiceCommandLineModel model)
        {
            if (string.IsNullOrEmpty(model.Entity))
            {
                throw new Exception("-e is required");
            }

            var namespaceService = GetService<NamespaceService>();
            var entityTypeResolver = GetService<IEntityReflector>();
            var entityPropertyResolver = GetService<IEntityPropertyResolver>();
            var areaNameResolver = GetService<IAreaNameResolver>();
            var scaffolder = GetService<ScaffoldingService>();

            var scaffoldingTasks = new List<Task>();

            string entityName = model.Entity;
            string areaName = areaNameResolver.Resolve(model.Entity);
            string serviceName = serviceName = $"{model.Entity}{ServiceSuffix}";

            string readEntityDtoName = $"{entityName}Result";
            string createEntityDtoName = $"Create{entityName}";
            string updateEntityDtoName = $"Update{entityName}";

            bool canUpdate = typeof(IUpdateAuditable).IsAssignableFrom(entityTypeResolver.GetEntityType(entityName));
            bool canDelete = typeof(IDeleteAuditable).IsAssignableFrom(entityTypeResolver.GetEntityType(entityName));
            bool canList = true; // TODO;

            dynamic serviceTemplateModel = new ServiceTemplateModel()
            {
                EntityName = model.Entity,
                AreaName = areaName,
                ServiceName = serviceName,
                ServiceNamespaceName = namespaceService.GetServiceNamespace(areaName),
                ServicesNamespaceName = namespaceService.GetServicesNamespace(),
                FrameworkServicesNamespaceName = namespaceService.GetFrameworkServicesNamespace(),
                EntitiesNamespaceName = namespaceService.GetFrameworkEntitiesNamespace(),
                EntityNamespaceName = namespaceService.GetFrameworkEntityNamespace(areaName),
                DbSetPropertyName = entityTypeResolver.GetDataSetPropertyName(entityName),
                EntityIdTypeName = entityTypeResolver.GetEntityIdType(entityName),
                CanUpdate = canUpdate,
                CanDelete = canDelete,
                CanList = canList,
                ReadEntityDtoName = readEntityDtoName,
                CreateEntityDtoName = createEntityDtoName,
                UpdateEntityDtoName = updateEntityDtoName
            };
            scaffoldingTasks.Add(scaffolder.ScaffoldServiceAsync(areaName, serviceName, serviceTemplateModel, model.Force));

            dynamic readDtoTemplateModel = new ReadDtoTemplateModel()
            {
                EntityName = model.Entity,
                EntityNamespaceName = namespaceService.GetFrameworkEntityNamespace(areaName),
                ReadEntityDtoName = readEntityDtoName,
                EntityProperties = entityPropertyResolver.Resolve(entityName),
                ServicesNamespaceName = namespaceService.GetServicesNamespace()
            };
            scaffoldingTasks.Add(scaffolder.ScaffoldReadDtoAsync(areaName, readEntityDtoName, readDtoTemplateModel, model.Force));

            if (canUpdate)
            {

            }

            await Task.WhenAll(scaffoldingTasks);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;
using Taggl.CodeGeneration.Services;
using Taggl.CodeGeneration.Services.Service;

namespace Taggl.CodeGeneration.Generators.DtoMappings
{
    public class DtoMappingsGenerator : IGenerator
    {
        private readonly IEntityAliasResolver _entityAliasResolver;
        private readonly IDtoAliasResolver _dtoAliasResolver;
        private readonly IAreaNameResolver _areaNameResolver;
        private readonly NamespaceService _namespaceService;
        private readonly OutputPathResolver _outputPathResolver;
        private readonly ScaffoldingService _scaffoldingService;
        private readonly FromEntityCommandLineModel _model;

        public DtoMappingsGenerator(
            IEntityAliasResolver entityAliasResolver,
            IDtoAliasResolver dtoAliasResolver,
            IAreaNameResolver areaNameResolver,
            NamespaceService namespaceService,
            OutputPathResolver outputPathResolver,
            ScaffoldingService scaffoldingService,
            FromEntityCommandLineModel model)
        {
            _entityAliasResolver = entityAliasResolver;
            _dtoAliasResolver = dtoAliasResolver;
            _areaNameResolver = areaNameResolver;
            _namespaceService = namespaceService;
            _outputPathResolver = outputPathResolver;
            _scaffoldingService = scaffoldingService;
            _model = model;
        }

        public async Task Generate()
        {
            var entityName = _model.Entity;
            var areaName = _areaNameResolver.Resolve(entityName);
            var aliasedEntityName = _entityAliasResolver.Resolve(entityName);
            var className = $"{aliasedEntityName}Mappings";

            var templateModel = new DtoMappingsTemplateModel()
            {
                ClassName = className,
                NamespaceName = _namespaceService.GetServiceMappingsNamespace(areaName),
                EntityName = entityName,
                EntityNamespaceName = _namespaceService.GetFrameworkEntityNamespace(areaName),
                ModelsNamespaceName = _namespaceService.GetServiceModelsNamespace(areaName),
                ReadDtoName = _dtoAliasResolver.ResolveReadDtoAlias(aliasedEntityName),
                CreateDtoName = _dtoAliasResolver.ResolveCreateDtoAlias(aliasedEntityName)
            };

            await _scaffoldingService.ScaffoldAsync(
                _outputPathResolver.GetServiceMappingsPath(areaName),
                className,
                "DtoMappingsTemplate",
                templateModel,
                _model.Force);
        }
    }
}

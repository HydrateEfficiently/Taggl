using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services;

namespace Taggl.CodeGeneration.Generators.ReadDto
{
    public class ReadDtoGenerator : IGenerator
    {
        private readonly NamespaceService _namespaceService;
        private readonly IAreaNameResolver _areaNameResolver;
        private readonly OutputClassNameResolver _outputClassNameResolver;
        private readonly OutputPathResolver _outputPathResolver;
        private readonly IEntityPropertyResolver _entityPropertyResolve;
        private readonly ScaffoldingService _scaffoldingService;
        private readonly ReadDtoCommandLineModel _model;

        public ReadDtoGenerator(
            NamespaceService namespaceService,
            IAreaNameResolver areaNameResolver,
            OutputClassNameResolver outputClassNameResolver,
            OutputPathResolver outputPathResolver,
            IEntityPropertyResolver entityPropertyResolve,
            ScaffoldingService scaffoldingService,
            ReadDtoCommandLineModel model)
        {
            _namespaceService = namespaceService;
            _areaNameResolver = areaNameResolver;
            _outputClassNameResolver = outputClassNameResolver;
            _outputPathResolver = outputPathResolver;
            _entityPropertyResolve = entityPropertyResolve;
            _scaffoldingService = scaffoldingService;
            _model = model;
        }

        public async Task Generate()
        {
            string entityName = _model.Entity;
            string areaName = _areaNameResolver.Resolve(entityName);
            string readDtoName = _outputClassNameResolver.GetReadDtoName(entityName);

            dynamic readDtoTemplateModel = new ReadDtoTemplateModel()
            {
                EntityName = entityName,
                EntityNamespaceName = _namespaceService.GetFrameworkEntityNamespace(areaName),
                ReadEntityDtoName = readDtoName,
                EntityProperties = _entityPropertyResolve.Resolve(entityName),
                ServicesNamespaceName = _namespaceService.GetServicesNamespace()
            };

            await _scaffoldingService.ScaffoldAsync(
                _outputPathResolver.GetServiceModelsPath(areaName),
                readDtoName,
                "ReadDtoTemplate",
                readDtoTemplateModel,
                _model.Force);
        }
    }
}

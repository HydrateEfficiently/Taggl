using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;
using Taggl.CodeGeneration.Exceptions;
using Taggl.CodeGeneration.Services;
using Taggl.CodeGeneration.Services.Properties;
using Taggl.CodeGeneration.Services.Service;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration.Generators.ReadDto
{
    public class ReadDtoGenerator : IGenerator
    {
        private readonly IEntityReflector _entityReflector;
        private readonly IEntityAliasResolver _entityAliasResolver;
        private readonly IDtoAliasResolver _dtoAliasResolver;
        private readonly IPropertyTypeNameResolver _propertyNameResolver;
        private readonly NamespaceService _namespaceService;
        private readonly IAreaNameResolver _areaNameResolver;
        private readonly OutputPathResolver _outputPathResolver;
        private readonly ScaffoldingService _scaffoldingService;
        private readonly EntityGenerateCommandLineModel _model;

        public ReadDtoGenerator(
            IEntityReflector entityReflector,
            IEntityAliasResolver entityAliasResolver,
            IDtoAliasResolver dtoAliasResolver,
            IPropertyTypeNameResolver propertyNameResolver,
            NamespaceService namespaceService,
            IAreaNameResolver areaNameResolver,
            OutputPathResolver outputPathResolver,
            ScaffoldingService scaffoldingService,
            EntityGenerateCommandLineModel model)
        {
            _entityReflector = entityReflector;
            _entityAliasResolver = entityAliasResolver;
            _dtoAliasResolver = dtoAliasResolver;
            _propertyNameResolver = propertyNameResolver;
            _namespaceService = namespaceService;
            _areaNameResolver = areaNameResolver;
            _outputPathResolver = outputPathResolver;
            _scaffoldingService = scaffoldingService;
            _model = model;
        }

        public async Task Generate()
        {
            string entityName = _model.Entity;
            string areaName = _areaNameResolver.Resolve(entityName);
            string readDtoName = _dtoAliasResolver.ResolveReadDtoAlias(entityName);
            string namespaceName = _namespaceService.GetServiceModelsNamespace(areaName);

            var properties = new List<PropertyDeclarationModel>();
            var readDtoProperties = new List<ReadDtoPropertyDeclarationModel>();
            var readDtoNamespaceNames = new List<string>();

            var entityType = _entityReflector.GetEntityType(entityName);
            var propertiesToGenerate = entityType.GetProperties()
                .Where(pi => !pi.ShouldIgnoreForDto(DtoType.Read));
            foreach (var property in propertiesToGenerate)
            {
                string propertyTypeName = property.PropertyType.Name;
                Type foreignKeyEntityType;
                if (_entityReflector.TryGetEntityType(propertyTypeName, out foreignKeyEntityType))
                {
                    string basePropertyTypeName = _entityAliasResolver.Resolve(propertyTypeName);
                    var propertyDeclarationModel = new ReadDtoPropertyDeclarationModel()
                    {
                        BasePropertyTypeName = basePropertyTypeName,
                        PropertyTypeName = _dtoAliasResolver.ResolveReadDtoAlias(basePropertyTypeName),
                        PropertyName = property.Name
                    };
                    readDtoProperties.Add(propertyDeclarationModel);
                    properties.Add(propertyDeclarationModel);

                    string foreignKeyAreaName = _areaNameResolver.Resolve(propertyTypeName);
                    string readDtoNamespaceName = _namespaceService.GetServiceNamespace(foreignKeyAreaName);
                    if (readDtoNamespaceName != namespaceName && 
                        !readDtoNamespaceNames.Contains(readDtoNamespaceName))
                    {
                        readDtoNamespaceNames.Add(readDtoNamespaceName);
                    }
                }
                else
                {
                    properties.Add(new PropertyDeclarationModel()
                    {
                        PropertyName = property.Name,
                        PropertyTypeName = _propertyNameResolver.Resolve(property)
                    });
                }
            }

            dynamic templateModel = new ReadDtoTemplateModel()
            {
                EntityName = entityName,
                EntityNamespaceName = _namespaceService.GetFrameworkEntityNamespace(areaName),
                ReadEntityDtoName = readDtoName,
                NamespaceName = namespaceName,
                ReadDtoNamespaceNames = readDtoNamespaceNames,
                ReadDtoProperties = readDtoProperties,
                Properties = properties
            };

            try
            {
                await _scaffoldingService.ScaffoldAsync(
                    _outputPathResolver.GetServiceModelsPath(areaName),
                    readDtoName,
                    "ReadDtoTemplate",
                    templateModel,
                    _model.Force);
            }
            catch (GeneratedFileExistsException)
            {
            }

            await _scaffoldingService.ScaffoldAsync(
                _outputPathResolver.GetServiceModelsPath(areaName),
                $"{readDtoName}.Generated",
                "ReadDtoGeneratedTemplate",
                templateModel,
                force: true);
        }
    }
}

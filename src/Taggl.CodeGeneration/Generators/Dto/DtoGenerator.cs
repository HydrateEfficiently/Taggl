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

namespace Taggl.CodeGeneration.Generators.Dto
{
    public class DtoGenerator : IGenerator
    {
        private readonly IEntityReflector _entityReflector;
        private readonly IEntityAliasResolver _entityAliasResolver;
        private readonly IDtoAliasResolver _dtoAliasResolver;
        private readonly IPropertyTypeNameResolver _propertyNameResolver;
        private readonly NamespaceService _namespaceService;
        private readonly IAreaNameResolver _areaNameResolver;
        private readonly OutputPathResolver _outputPathResolver;
        private readonly ScaffoldingService _scaffoldingService;
        private readonly DtoCommandLineModel _model;

        public DtoGenerator(
            IEntityReflector entityReflector,
            IEntityAliasResolver entityAliasResolver,
            IDtoAliasResolver dtoAliasResolver,
            IPropertyTypeNameResolver propertyNameResolver,
            NamespaceService namespaceService,
            IAreaNameResolver areaNameResolver,
            OutputPathResolver outputPathResolver,
            ScaffoldingService scaffoldingService,
            DtoCommandLineModel model)
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
            bool generateReadDto = false;
            bool generateCreateDto = false;
            bool generateUpdateDto = false;

            if (!_model.Read && !_model.Create && !_model.Update)
            {
                generateReadDto = generateCreateDto = generateUpdateDto = true;
            }
            else
            {
                generateReadDto = _model.Read;
                generateCreateDto = _model.Create;
                generateUpdateDto = _model.Update;
            }

            var generateTasks = new List<Task>();
            if (generateReadDto)
            {
                generateTasks.Add(Generate(DtoType.Read, _model.Force));
            }
            if (generateCreateDto)
            {
                generateTasks.Add(Generate(DtoType.Create, _model.Force));
            }
            if (generateUpdateDto)
            {
                //generateTasks.Add(Generate(DtoType.Update, _model.Force));
            }
            await Task.WhenAll(generateTasks);
        }

        private async Task Generate(DtoType dtoType, bool force)
        {
            string entityName = _model.Entity;
            string areaName = _areaNameResolver.Resolve(entityName);
            string dtoName = _dtoAliasResolver.Resolve(entityName, dtoType);
            string namespaceName = _namespaceService.GetServiceModelsNamespace(areaName);

            var properties = new List<PropertyDeclarationModel>();
            var dtoProperties = new List<DtoPropertyDeclarationModel>();
            var dtoNamespaceNames = new List<string>();

            var entityType = _entityReflector.GetEntityType(entityName);
            var propertiesToGenerate = entityType.GetProperties()
                .Where(pi => !pi.ShouldIgnoreForDto(dtoType));

            foreach (var property in propertiesToGenerate)
            {
                string propertyTypeName = property.PropertyType.Name;
                Type foreignKeyEntityType;
                if (_entityReflector.TryGetEntityType(propertyTypeName, out foreignKeyEntityType))
                {
                    string basePropertyTypeName = _entityAliasResolver.Resolve(propertyTypeName);
                    var propertyDeclarationModel = new DtoPropertyDeclarationModel()
                    {
                        BasePropertyTypeName = basePropertyTypeName,
                        PropertyTypeName = _dtoAliasResolver.Resolve(basePropertyTypeName, dtoType),
                        PropertyName = property.Name
                    };
                    dtoProperties.Add(propertyDeclarationModel);
                    properties.Add(propertyDeclarationModel);

                    string foreignKeyAreaName = _areaNameResolver.Resolve(propertyTypeName);
                    string dtoNamespaceName = _namespaceService.GetServiceNamespace(foreignKeyAreaName);
                    if (dtoNamespaceName != namespaceName &&
                        !dtoNamespaceNames.Contains(dtoNamespaceName))
                    {
                        dtoNamespaceNames.Add(dtoNamespaceName);
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

            dynamic templateModel = new DtoTemplateModel()
            {
                EntityName = entityName,
                EntityNamespaceName = _namespaceService.GetFrameworkEntityNamespace(areaName),
                DtoName = dtoName,
                NamespaceName = namespaceName,
                DtoNamespaceNames = dtoNamespaceNames,
                DtoProperties = dtoProperties,
                Properties = properties
            };

            string dtoTemplate;
            string dtoGeneratedTemplate;
            switch (dtoType)
            {
                case DtoType.Read:
                    dtoTemplate = "ReadDtoTemplate";
                    dtoGeneratedTemplate = "ReadDtoGeneratedTemplate";
                    break;
                case DtoType.Create:
                    dtoTemplate = "CreateDtoTemplate";
                    dtoGeneratedTemplate = "CreateDtoGeneratedTemplate";
                    break;
                case DtoType.Update:
                    dtoTemplate = "UpdateDtoTemplate";
                    dtoGeneratedTemplate = "UpdateDtoGeneratedTemplate";
                    break;
                default:
                    throw new InvalidOperationException();
            }

            try
            {
                await _scaffoldingService.ScaffoldAsync(
                    _outputPathResolver.GetServiceModelsPath(areaName),
                    dtoName,
                    dtoTemplate,
                    templateModel,
                    _model.Force);
            }
            catch (GeneratedFileExistsException)
            {
            }

            await _scaffoldingService.ScaffoldAsync(
                _outputPathResolver.GetServiceModelsPath(areaName),
                $"{dtoName}.Generated",
                dtoGeneratedTemplate,
                templateModel,
                force: true);
        }
    }
}

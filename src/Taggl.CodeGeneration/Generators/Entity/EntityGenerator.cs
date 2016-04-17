using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services;
using Taggl.CodeGeneration.Services.Properties;
using Taggl.CodeGeneration.Utility;
using Taggl.Framework.Models;

namespace Taggl.CodeGeneration.Generators.Entity
{
    public class EntityGenerator : IGenerator
    {
        private readonly ScaffoldingService _scaffoldingService;
        private readonly OutputPathResolver _outputPathResolver;
        private readonly NamespaceService _namespaceService;
        private readonly IIdentityTypeNameResolver _identityTypeNameResolver;
        private readonly IPropertyDeclarationFactory _propertyDeclarationFactory;
        private readonly EntityCommandLineModel _model;

        public EntityGenerator(
            ScaffoldingService scaffoldingService,
            OutputPathResolver outputPathResolver,
            NamespaceService namespaceService,
            IIdentityTypeNameResolver identityTypeNameResolver,
            IPropertyDeclarationFactory propertyDeclarationFactory,
            EntityCommandLineModel model)
        {
            _scaffoldingService = scaffoldingService;
            _outputPathResolver = outputPathResolver;
            _namespaceService = namespaceService;
            _identityTypeNameResolver = identityTypeNameResolver;
            _propertyDeclarationFactory = propertyDeclarationFactory;
            _model = model;
        }

        public async Task Generate()
        {
            string areaName = _model.Area;
            string entityName = _model.Entity;

            var properties = new List<PropertyDeclarationModel>();
            var interfaces = new List<string>();

            if (_model.AuditCreate)
            {
                interfaces.Add(nameof(ICreateAuditable));
                properties.AddRange(_propertyDeclarationFactory.CreateInterfaceProperties(
                    typeof(ICreateAuditable),
                    new Dictionary<string, PropertyDeclarationModelOptions>()
                    {
                        {
                            nameof(ICreateAuditable.CreatedBy),
                            new PropertyDeclarationModelOptions()
                            {
                                IsVirtual = true
                            }
                        }
                    }));
            }

            if (_model.AuditUpdate)
            {
                interfaces.Add(nameof(IUpdateAuditable));
                properties.AddRange(_propertyDeclarationFactory.CreateInterfaceProperties(
                    typeof(IUpdateAuditable),
                    new Dictionary<string, PropertyDeclarationModelOptions>()
                    {
                        {
                            nameof(IUpdateAuditable.UpdatedBy),
                            new PropertyDeclarationModelOptions()
                            {
                                IsVirtual = true
                            }
                        }
                    }));
            }

            if (_model.AuditDelete)
            {
                interfaces.Add(nameof(IDeleteAuditable));
                properties.AddRange(_propertyDeclarationFactory.CreateInterfaceProperties(
                    typeof(IDeleteAuditable),
                    new Dictionary<string, PropertyDeclarationModelOptions>()
                    {
                        {
                            nameof(IDeleteAuditable.DeletedBy),
                            new PropertyDeclarationModelOptions()
                            {
                                IsVirtual = true
                            }
                        }
                    }));
            }

            var templateModel = new EntityTemplateModel()
            {
                EntityName = entityName,
                AreaName = areaName,
                FrameworkEntityNamespace = _namespaceService.GetFrameworkEntityNamespace(areaName),
                FrameworkEntitiesNamespace = _namespaceService.GetFrameworkEntitiesNamespace(),
                IdentityTypeName = _identityTypeNameResolver.Resolve(_model),
                Interfaces = interfaces,
                Properties = properties
            };

            await _scaffoldingService.ScaffoldAsync(
                _outputPathResolver.GetFrameworkEntityNamespace("Vehicles"),
                entityName,
                "EntityTemplate",
                templateModel,
                _model.Force);
        }
    }
}

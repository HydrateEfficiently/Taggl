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

namespace Taggl.CodeGeneration.Service
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

            var scaffolder = ActivatorUtilities.CreateInstance<Scaffolder>(_serviceProvider);
            var scaffoldingTasks = new List<Task>();

            EntityName = model.Entity;

            dynamic serviceTemplateModel = new ServiceTemplateModel()
            {
                EntityName = EntityName,
                AreaName = AreaName,
                ServiceName = ServiceName,
                ServiceNamespaceName = $"{ServicesNamespaceName}.{AreaName}",
                ServicesNamespaceName = ServicesNamespaceName,
                FrameworkServicesNamespaceName = $"{FrameworkNamespaceName}.Services",
                EntitiesNamespaceName = _nameResolver.GetModelsNamespace(),
                EntityNamespaceName = _nameResolver.GetEntityNamespace(AreaName),
                DbSetPropertyName = DbSetPropertyName,
                EntityIdTypeName = EntityIdTypeName,
                CanUpdate = CanUpdate,
                CanDelete = CanDelete,
                CanList = CanList,
                ReadEntityDtoName = ReadEntityDtoName,
                CreateEntityDtoName = CreateEntityDtoName,
                UpdateEntityDtoName = UpdateEntityDtoName
            };
            scaffoldingTasks.Add(_scaffolder.ScaffoldServiceAsync(AreaName, ServiceName, serviceTemplateModel, model.Force));

            dynamic readDtoTemplateModel = new ReadDtoTemplateModel()
            {
                EntityName = EntityName,
                EntityNamespaceName = _nameResolver.GetEntityNamespace(AreaName),
                ReadEntityDtoName = ReadEntityDtoName,
                EntityProperties = EntityProperties,
                ServicesNamespaceName = ServicesNamespaceName
            };
            scaffoldingTasks.Add(_scaffolder.ScaffoldReadDtoAsync(AreaName, ReadEntityDtoName, readDtoTemplateModel, model.Force));

            if (CanUpdate)
            {

            }

            await Task.WhenAll(scaffoldingTasks);
        }

        #region Properties
        
        private string EntityName { get; set; }

        private string _frameworkNamespaceName;
        private string FrameworkNamespaceName
        {
            get
            {
                if (_frameworkNamespaceName == null)
                {
                    _frameworkNamespaceName = _nameResolver.GetFrameworkNamespace();
                }
                return _frameworkNamespaceName;
            }
        }

        private Assembly _frameworkAssembly;
        private Assembly FrameworkAssembly
        {
            get
            {
                if (_frameworkAssembly == null)
                {
                    var frameworkAssemblyName = Assembly
                        .GetExecutingAssembly()
                        .GetReferencedAssemblies()
                        .Where(a => a.Name == FrameworkNamespaceName)
                        .FirstOrDefault();

                    if (frameworkAssemblyName == null)
                    {
                        throw new InvalidOperationException($"Could not find assembly with name {FrameworkNamespaceName}");
                    }

                    _frameworkAssembly = Assembly.Load(frameworkAssemblyName);
                }
                return _frameworkAssembly;
            }
        }

        private Type _entityType;
        private Type EntityType
        {
            get
            {
                if (_entityType == null)
                {
                    var entityTypes = FrameworkAssembly.GetTypes().Where(t => t.Name == EntityName);
                    if (entityTypes.Count() == 0)
                    {
                        throw new InvalidOperationException($"Could not find entity of type ${EntityName} in assembly {FrameworkNamespaceName}");
                    }
                    else if (entityTypes.Count() > 1)
                    {
                        throw new InvalidOperationException($"Found multiple entities: ${string.Join(", ", entityTypes.Select(e => e.FullName))}");
                    }
                    _entityType = entityTypes.Single();
                }
                return _entityType;
            }
        }

        private string _dbContextTypeName;
        private string DbContextTypeName
        {
            get
            {
                if (_dbContextTypeName == null)
                {
                    _dbContextTypeName = $"{ServicesNamespaceName}.ApplicationDbContext";
                }
                return _dbContextTypeName;
            }
        }

        private Type _dbContextType;
        private Type DbContextType
        {
            get
            {
                if (_dbContextType == null)
                {
                    
                    _dbContextType = Type.GetType($"{DbContextTypeName},{ServicesNamespaceName}");
                    if (_dbContextType == null)
                    {
                        throw new InvalidOperationException($"Could not find data context of type {DbContextTypeName} in assembly {ServicesNamespaceName}");
                    }
                }
                return _dbContextType;
            }
        }
        
        private string _modelNamespace;
        private string ModelNamespace
        {
            get
            {
                if (_modelNamespace == null)
                {
                    _modelNamespace = _nameResolver.GetModelsNamespace();
                }
                return _modelNamespace;
            }
        }

        private string _areaName;
        private string AreaName
        {
            get
            {
                if (_areaName == null)
                {
                    var entityNameQualifiedFromModels = EntityType.FullName
                        .Replace($"{ModelNamespace}.", string.Empty)
                        .Split('.');
                    if (entityNameQualifiedFromModels.Count() != 2)
                    {
                        throw new InvalidOperationException($"Entity must be two folders below {ModelNamespace}");
                    }
                    _areaName = entityNameQualifiedFromModels.First();
                }
                return _areaName;
            }
        }

        private string _serviceName;
        private string ServiceName
        {
            get
            {
                if (_serviceName == null)
                {
                    _serviceName = $"{EntityName}{ServiceSuffix}";
                }
                return _serviceName;
            }
        }

        private string _serviceNamespaceName;
        private string ServiceNamespaceName
        {
            get
            {
                if (_serviceNamespaceName == null)
                {

                }
                return _serviceNamespaceName;
            }
        }

        private string _servicesNamespaceName;
        private string ServicesNamespaceName
        {
            get
            {
                if (_servicesNamespaceName == null)
                {
                    _servicesNamespaceName = _nameResolver.GetServicesNamespace();
                }
                return _servicesNamespaceName;
            }
        }

        private string _frameworkServicesNamespaceName;
        private string FrameworkServicesNamespaceName
        {
            get
            {
                if (_frameworkServicesNamespaceName == null)
                {

                }
                return _frameworkServicesNamespaceName;
            }
        }

        private string _entitiesNamespaceName;
        private string EntitiesNamespaceName
        {
            get
            {
                if (_entitiesNamespaceName == null)
                {

                }
                return _entitiesNamespaceName;
            }
        }

        private string _entityNamespaceName;
        private string EntityNamespaceName
        {
            get
            {
                if (_entityNamespaceName == null)
                {

                }
                return _entityNamespaceName;
            }
        }

        private string _dbSetPropertyName;
        private string DbSetPropertyName
        {
            get
            {
                if (_dbSetPropertyName == null)
                {
                    var genericDbSetType = typeof(DbSet<>);
                    var dbSetType = genericDbSetType.MakeGenericType(EntityType);
                    var dbSetProperty = DbContextType
                        .GetProperties()
                        .Where(pi => pi.PropertyType == dbSetType)
                        .FirstOrDefault();
                    if (dbSetProperty == null)
                    {
                        throw new Exception($"Could not find property with type DbSet<{EntityName}> on {DbContextTypeName}");
                    }
                    _dbSetPropertyName = dbSetProperty.Name;
                }
                return _dbSetPropertyName;
            }
        }

        private string _entityIdTypeName;
        private string EntityIdTypeName
        {
            get
            {
                if (_entityIdTypeName == null)
                {
                    var entityIdType = EntityType
                        .GetProperties()
                        .Where(pi => pi.Name == "Id")
                        .FirstOrDefault();
                    if (entityIdType == null)
                    {
                        throw new InvalidOperationException("Entity must be keyed by a property named Id");
                    }
                    _entityIdTypeName = entityIdType.PropertyType.Name;
                }
                return _entityIdTypeName;
            }
        }

        private bool? _canUpdate;
        private bool CanUpdate
        {
            get
            {
                if (_canUpdate == null)
                {
                    _canUpdate = typeof(IUpdateAuditable).IsAssignableFrom(EntityType);
                }
                return _canUpdate.Value;
            }
        }

        private bool? _canDelete;
        private bool CanDelete
        {
            get
            {
                if (_canDelete == null)
                {
                    _canDelete = typeof(IDeleteAuditable).IsAssignableFrom(EntityType);
                }
                return _canDelete.Value;
            }
        }

        private bool? _canList;
        private bool CanList
        {
            get
            {
                if (_canList == null)
                {
                    _canList = true; // TODO
                }
                return _canList.Value;
            }
        }

        private string _readEntityDtoName;
        private string ReadEntityDtoName
        {
            get
            {
                if (_readEntityDtoName == null)
                {
                    _readEntityDtoName = $"{EntityName}Result";
                }
                return _readEntityDtoName;
            }
        }

        private string _createEntityDtoName;
        private string CreateEntityDtoName
        {
            get
            {
                if (_createEntityDtoName == null)
                {
                    _createEntityDtoName = $"Create{EntityName}";
                }
                return _createEntityDtoName;
            }
        }

        private string _updateEntityDtoName;
        private string UpdateEntityDtoName
        {
            get
            {
                if (_updateEntityDtoName == null)
                {
                    _updateEntityDtoName = $"Update{EntityName}";
                }
                return _updateEntityDtoName;
            }
        }

        private IEnumerable<PropertyDeclarationModel> _entityProperties;
        public IEnumerable<PropertyDeclarationModel> EntityProperties
        {
            get
            {
                if (_entityProperties == null)
                {
                    _entityProperties = EntityType.GetProperties()
                        .Select(pi => new PropertyDeclarationModel()
                        {
                            ResolvedTypeName = pi.ResolveTypeName(),
                            Name = pi.Name
                        });
                }
                return _entityProperties;
            }
        }

        #endregion
    }
}

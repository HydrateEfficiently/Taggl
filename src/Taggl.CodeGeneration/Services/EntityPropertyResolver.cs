using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.Properties;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration.Services
{
    public interface IEntityPropertyResolver
    {
        IEnumerable<EntityPropertyDeclarationModel> Resolve(string entityName);
    }

    public class EntityPropertyResolver : IEntityPropertyResolver
    {
        private readonly IEntityReflector _entityTypeResolver;
        private readonly IPropertyTypeNameResolver _propertyTypeNameResolver;
        private readonly IEntityAliasResolver _entityAliasResolver;

        public EntityPropertyResolver(
            IEntityReflector entityTypeResolver,
            IPropertyTypeNameResolver propertyTypeNameResolver,
            IEntityAliasResolver entityAliasResolver)
        {
            _entityTypeResolver = entityTypeResolver;
            _propertyTypeNameResolver = propertyTypeNameResolver;
            _entityAliasResolver = entityAliasResolver;
        }

        public IEnumerable<EntityPropertyDeclarationModel> Resolve(string entityName)
        {
            return _entityTypeResolver
                .GetEntityType(entityName)
                .GetProperties()
                .Select(pi => new EntityPropertyDeclarationModel()
                {
                    PropertyTypeName = _entityAliasResolver.Resolve(_propertyTypeNameResolver.Resolve(pi)),
                    PropertyName = pi.Name
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        public EntityPropertyResolver(
            IEntityReflector entityTypeResolver)
        {
            _entityTypeResolver = entityTypeResolver;
        }

        public IEnumerable<EntityPropertyDeclarationModel> Resolve(string entityName)
        {
            return _entityTypeResolver
                .GetEntityType(entityName)
                .GetProperties()
                .Select(pi => new EntityPropertyDeclarationModel()
                {
                    ResolvedTypeName = pi.ResolveTypeName(),
                    Name = pi.Name
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services.Properties
{
    public interface IPropertyDeclarationFactory
    {
        IEnumerable<PropertyDeclarationModel> CreateInterfaceProperties(
            Type interfaceType,
            Dictionary<string, PropertyDeclarationModelOptions> optionsByPropertyName = null);
    }

    public class PropertyDeclarationFactory : IPropertyDeclarationFactory
    {
        private readonly IPropertyTypeNameResolver _propertyTypeNameResolver;

        public PropertyDeclarationFactory(
            IPropertyTypeNameResolver propertyTypeNameResolver)
        {
            _propertyTypeNameResolver = propertyTypeNameResolver;
        }

        public IEnumerable<PropertyDeclarationModel> CreateInterfaceProperties(
            Type interfaceType,
            Dictionary<string, PropertyDeclarationModelOptions> optionsByPropertyName = null)
        {
            if (optionsByPropertyName == null)
            {
                optionsByPropertyName = new Dictionary<string, PropertyDeclarationModelOptions>();
            }

            var result = new List<PropertyDeclarationModel>();
            var properties = interfaceType.GetProperties();
            foreach (var pi in properties)
            {
                string propertyName = pi.Name;
                PropertyDeclarationModelOptions options;
                if (!optionsByPropertyName.TryGetValue(propertyName, out options))
                {
                    options = new PropertyDeclarationModelOptions();
                }

                string extraModifiers = string.Join(" ", new Dictionary<string, bool>()
                {
                    { "virtual", options.IsVirtual }
                }.Where(kvp => kvp.Value).Select(kvp => kvp.Key));
                
                result.Add(new PropertyDeclarationModel()
                {
                    AccessModifier = options.AccessModifier,
                    ExtraModifiers = extraModifiers,
                    ResolvedTypeName = _propertyTypeNameResolver.Resolve(pi),
                    Name = propertyName
                });
            }
            return result;
        }
    }
}

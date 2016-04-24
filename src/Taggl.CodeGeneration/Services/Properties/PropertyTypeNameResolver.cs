using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Utility;
using Taggl.Framework.Models.Identity;

namespace Taggl.CodeGeneration.Services.Properties
{
    public interface IPropertyTypeNameResolver
    {
        string Resolve(PropertyInfo pi);
    }

    public class PropertyTypeNameResolver : IPropertyTypeNameResolver
    {
        public string Resolve(PropertyInfo pi)
        {
            return pi.PropertyType.GetRawOutputName();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.CodeGeneration.Utility
{
    public static class PropertyInfoExtensions
    {
        public static string ResolveTypeName(
            this PropertyInfo pi)
        {
            var type = pi.PropertyType;
            var underlyingNullableType = Nullable.GetUnderlyingType(type);
            if (underlyingNullableType != null)
            {
                var underlyingType = Nullable.GetUnderlyingType(type);
                return $"{underlyingType.GetPrimitiveTypeName()}?";
            }
            else if (type == typeof(ApplicationUser))
            {
                return "UserResult";
            }
            return type.GetPrimitiveTypeName();
        }
    }
}

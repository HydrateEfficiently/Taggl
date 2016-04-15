using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Utility
{
    public static class TypeExtensions
    {

        public static string GetPrimitiveTypeName(
            this Type type)
        {
            if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(string))
            {
                return "string";
            }
            return type.Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Utility
{
    public static class MethodInfoExtensions
    {
        public static bool IsAsync(this MethodInfo methodInfo)
        {
            var returnType = methodInfo.ReturnType;
            return returnType.Equals(typeof(Task)) ||
                returnType.BaseType.Equals(typeof(Task));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;

namespace Taggl.CodeGeneration.Utility
{
    public static class PropertyInfoExtensions
    {
        public static bool ShouldIgnoreForDto(
            this PropertyInfo propertyInfo,
            DtoType dtoType)
        {
            var dtoAttribute = propertyInfo.GetCustomAttribute<DtoGenerateIgnoreAttribute>();
            if (dtoAttribute == null)
            {
                return false;
            }

            if (dtoAttribute.DtoTypes.Count() == 0)
            {
                return true;
            }

            return dtoAttribute.DtoTypes.Contains(dtoType);
        }
    }
}

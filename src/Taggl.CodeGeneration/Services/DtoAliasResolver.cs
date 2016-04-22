﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;

namespace Taggl.CodeGeneration.Services
{
    public interface IDtoAliasResolver
    {
        string Resolve(string entityAlias, DtoType dtoType);
    }

    public class DtoAliasResolver : IDtoAliasResolver
    {
        public string Resolve(string entityAlias, DtoType dtoType)
        {
            switch (dtoType)
            {
                case DtoType.Read:
                    return $"{entityAlias}Result";
                case DtoType.Create:
                    return $"{entityAlias}Create";
                case DtoType.Update:
                    return $"{entityAlias}Update";
                default:
                    throw new InvalidOperationException("Invalid DtoType");
            }
        }
    }
}

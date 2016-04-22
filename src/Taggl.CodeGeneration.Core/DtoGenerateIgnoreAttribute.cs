﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Core
{
    public class DtoGenerateIgnoreAttribute : Attribute
    {
        public IEnumerable<DtoType> DtoTypes { get; private set; }

        public DtoGenerateIgnoreAttribute() : this(DtoType.Read, DtoType.Create, DtoType.Update) { }

        public DtoGenerateIgnoreAttribute(params DtoType[] dtoTypes) : base()
        {
            DtoTypes = dtoTypes;
        }
    }
}

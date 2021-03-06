﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Models
{
    public interface ISearchableName : ISearchable
    {
        string Name { get; set; }

        string NameNormalized { get; set; }
    }
}

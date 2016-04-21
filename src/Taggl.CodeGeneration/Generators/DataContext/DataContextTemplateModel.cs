﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Generators.DataContext
{
    public class DataContextTemplateModel
    {
        public string ServicesNamespace { get; internal set; }
        public string UtilityNamespace { get; internal set; }
        public IEnumerable<string> EntityNamespaces { get; internal set; }
    }
}

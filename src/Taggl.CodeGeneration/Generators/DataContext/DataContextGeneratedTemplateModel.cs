using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Generators.DataContext
{
    public class DataContextGeneratedTemplateModel : DataContextTemplateModel
    {
        public IEnumerable<EntityDeclarationModel> GeneratedEntities { get; internal set; }
    }
}

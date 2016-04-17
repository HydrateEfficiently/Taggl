using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Generators
{
    public interface IGenerator
    {
        Task Generate();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Commands.Models
{
    public interface HasIdentityCommandLineModel
    {
        string IdentityTypeName { get; set; }
    }
}

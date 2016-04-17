using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;

namespace Taggl.CodeGeneration.Services
{
    public interface IIdentityTypeNameResolver
    {
        string Resolve(HasIdentityCommandLineModel model);
    }

    public class IdentityTypeNameResolver : IIdentityTypeNameResolver
    {
        public string Resolve(HasIdentityCommandLineModel model)
        {
            string id = model.IdentityTypeName;
            if (string.IsNullOrWhiteSpace(id))
            {
                id = "g";
            }

            switch (id)
            {
                case "g":
                    return "Guid";
                case "i":
                    return "int";
                default:
                    throw new InvalidOperationException("Invalid value for -i");
            }
        }
    }
}

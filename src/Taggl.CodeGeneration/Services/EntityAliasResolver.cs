using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.CodeGeneration.Services
{
    public interface IEntityAliasResolver
    {
        string Resolve(string typeName);
    }

    public class EntityAliasResolver : IEntityAliasResolver
    {
        private static readonly Dictionary<string, string> __frameworkMappings =
            new Dictionary<string, string>()
            {
                { nameof(ApplicationUser), "User" }
            };

        public string Resolve(string typeName)
        {
            string result;
            if (__frameworkMappings.TryGetValue(typeName, out result)) { }
            return result;
        }
    }
}

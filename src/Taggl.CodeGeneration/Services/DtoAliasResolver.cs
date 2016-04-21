using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.CodeGeneration.Services
{
    public interface IDtoAliasResolver
    {
        string ResolveReadDtoAlias(string entityAlias);

        string ResolveCreateDtoAlias(string entityAlias);

        string ResolveUpdateDtoAlias(string entityAlias);
    }

    public class DtoAliasResolver : IDtoAliasResolver
    {
        public string ResolveReadDtoAlias(string entityAlias)
        {
            return $"{entityAlias}Result";
        }

        public string ResolveCreateDtoAlias(string entityAlias)
        {
            return $"{entityAlias}Create";
        }

        public string ResolveUpdateDtoAlias(string entityAlias)
        {
            return $"{entityAlias}Update";
        }
    }
}
